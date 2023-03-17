using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UtilityAI.Core;

public class DefendSoldierPartol : StateMachineBehaviour
{
    private NavMeshAgent agent;
    private int destinationPoint = 0;
    private List<Transform> walkingPlaces;
    private static readonly int enemyALayerMask = 1 << 7;
    private Transform defendSoldierTransform;
    private SoldierInformation defendSoldierInformation;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        walkingPlaces = GameObject.FindGameObjectsWithTag(Constants.CastleBPatrolTag).Select(go => go.transform).ToList();
        defendSoldierTransform = animator.GetComponent<Transform>();
        defendSoldierInformation = animator.GetComponent<SoldierInformation>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!agent.pathPending && agent.remainingDistance < Constants.DefenceSoldierWalkingDistance)
        {
            Patrol();
        }

        var enemyDistance = GetEnemyDistance();
        if (enemyDistance <= 10f && enemyDistance > 0)
        {
            animator.SetTrigger(Constants.Run);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(defendSoldierInformation.Enemy.transform.position);
        animator.ResetTrigger(Constants.Run);
    }

    private void Patrol()
    {  
        if (walkingPlaces.Count == 0)
        {
            return;
        }
        agent.SetDestination(walkingPlaces[destinationPoint].position);
        destinationPoint = (destinationPoint + 1) % walkingPlaces.Count;
    }

    public float GetEnemyDistance()
    {
        Collider[] colliders = Physics.OverlapSphere(defendSoldierTransform.position, 10f, enemyALayerMask);
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
            float currentEnemyDistance = Vector3.Distance(defendSoldierTransform.position, colliders[i].transform.position);
            if (currentEnemyDistance < distance && EnemyIsAlive(colliders[i].gameObject))
            {
                closestEnemyIndex = i;
                distance = currentEnemyDistance;
            }
        }
        defendSoldierInformation.Enemy = colliders[closestEnemyIndex].gameObject;
        return distance;
    }

    private bool EnemyIsAlive(GameObject enemy)
    {
        return enemy.transform.root.GetComponent<SoldierInformation>().IsAlive;
    }
}
