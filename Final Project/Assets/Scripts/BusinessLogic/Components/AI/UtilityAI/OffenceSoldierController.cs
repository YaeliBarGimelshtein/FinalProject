using Assets.Scripts.Contract.NPC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UtilityAI.Core;

public class OffenceSoldierController : Character, IOfenceSoldierBehaviour
{
    public AIBrain aiBrain { get; set; }
    public Animator animator { get; set; }
    public bool finishExecute { get; set; }
    public Action[] actionsAvailable;
    public GameObject king;
    public Transform homePosition;

    private NavMeshAgent agent;
    private SoldierInformation information;
    private static readonly int enemyBLayerMask = 1 << 3;

    // Start is called before the first frame update
    void Start()
    {
        aiBrain = GetComponent<AIBrain>();
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        information = GetComponent<SoldierInformation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (aiBrain.finishedDeciding && finishExecute)
        {
            aiBrain.finishedDeciding = false;
            finishExecute = false;
            aiBrain.bestAction.Execute(this);
        }
    }

    public void OnFinishedAction()
    {
        aiBrain.DecideBestAction(actionsAvailable);
    }


    #region ConsiderationsWorldData
    public float GetEnemyDistance()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 10f, enemyBLayerMask);
        if (colliders.Length > 0)
        {
            return GetClosestEnemy(colliders);
        }
        return 10f;
    }

    private float GetClosestEnemy(Collider[] colliders)
    {
        float distance = 11f;
        int closestEnemyIndex = 0;

        for (int i = 0; i < colliders.Length; i++)
        {
            float currentEnemyDistance = Vector3.Distance(transform.position, colliders[i].transform.position);
            if (currentEnemyDistance < distance && EnemyIsAlive(colliders[i].gameObject))
            {
                closestEnemyIndex = i;
                distance = currentEnemyDistance;
            }
        }
        information.Enemy = colliders[closestEnemyIndex].gameObject;
        return distance;
    }

    public float GetSoldierHealth()
    {
        return information.Health;
    }

    public float GetKingDistance()
    {
        return Vector3.Distance(transform.position, king.transform.position);
    }

    private bool EnemyIsAlive(GameObject enemyObject)
    {
        return enemyObject.GetComponent<SoldierInformation>().IsAlive;
    }
    #endregion



    public void Attack()
    {
        StartCoroutine(AttackCoroutine());
    }

    IEnumerator AttackCoroutine()
    {
        Debug.Log("performing best action = Attack");
        animator.SetTrigger(Constants.Attack);
        information.IsAttacking = true;
        gameObject.transform.LookAt(information.Enemy.transform);
        yield return new WaitForSeconds(2f);
        information.IsAttacking = false;
        finishExecute = true;
    }

    public void Fallback()
    {
        StartCoroutine(FallbackCoroutine());
    }

    IEnumerator FallbackCoroutine()
    {
        Debug.Log("performing best action = Fallback");
        agent.destination = homePosition.position;
        animator.SetTrigger(Constants.Run);
        agent.speed += 2;
        yield return new WaitForSeconds(0.7f);
        finishExecute = true;
    }

    public void FollowTheKing()
    {
        StartCoroutine(FollowTheKingCoroutine());
    }

    IEnumerator FollowTheKingCoroutine()
    {
        Debug.Log("performing best action = FollowTheKing");
        gameObject.transform.LookAt(king.transform);
        agent.destination = king.transform.position;
        animator.SetTrigger(Constants.Walk);
        yield return new WaitForSeconds(1.033f);
        finishExecute = true;
    }

    public void ProtectTheKing()
    {
        Debug.Log("performing best action = ProtectTheKing");
        gameObject.transform.LookAt(information.Enemy.transform);
        agent.destination = information.Enemy.transform.position;
        finishExecute = true;
    }
}
