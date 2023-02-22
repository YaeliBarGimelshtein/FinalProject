using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class DefendSoldierPartol : StateMachineBehaviour
{
    private NavMeshAgent agent;
    private int destinationPoint = 0;
    private List<Transform> walkingPlaces;
    private static readonly int enemyALayerMask = 1 << 7;
    private Transform soldier;
    private Soldier soldierData;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        walkingPlaces = GameObject.FindGameObjectsWithTag("CastleBPatrol").Select(go => go.transform).ToList();
        soldier = animator.GetComponent<Transform>();
        soldierData = animator.GetComponent<Soldier>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!agent.pathPending && agent.remainingDistance < Constants.DefenceSoldierWalkingDistance)
        {
            Patrol();
        }

        var enemyDistance = GetEnemyDistance();
        if (enemyDistance <= 10f && enemyDistance != -1)
        {
            animator.SetTrigger("RunToEnemy");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(soldierData.Enemy.transform.position);
        animator.ResetTrigger("RunToEnemy");
    }

    private void Patrol()
    {
        
        // Returns if no points have been set up
        if (walkingPlaces.Count == 0)
        {
            return;
        }

        // Set the agent to go to the currently selected destination.
        agent.SetDestination(walkingPlaces[destinationPoint].position);

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destinationPoint = (destinationPoint + 1) % walkingPlaces.Count;
    }

    public float GetEnemyDistance()
    {
        Collider[] colliders = Physics.OverlapSphere(soldier.position, 10f, enemyALayerMask);
        if (colliders.Length > 0)
        {
            return GetClosestEnemy(colliders);
        }
        return -1f;
    }

    private float GetClosestEnemy(Collider[] colliders)
    {
        float distance = 20f;
        int closestEnemyIndex = 0;

        for (int i = 0; i < colliders.Length; i++)
        {
            float currentEnemyDistance = Vector3.Distance(soldier.position, colliders[i].transform.position);
            if (currentEnemyDistance < distance && EnemyIsAlive(colliders[i].gameObject))
            {
                closestEnemyIndex = i;
                distance = currentEnemyDistance;
            }
        }
        soldierData.Enemy = colliders[closestEnemyIndex].gameObject;
        return distance;
    }

    private bool EnemyIsAlive(GameObject enemy)
    {
        var lives = enemy.GetComponent<Soldier>().Health;
        if(lives > 0 )
        {
            return true;
        }
        return false;
    }
}
