using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UtilityAI.Core;

public class DefendSoldierAttack : StateMachineBehaviour
{
    private NavMeshAgent agent;
    private SoldierInformation defendSoldierInformation;
    private SoldierInformation enemyInformation;
    private Transform defendSoldierTransform;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        defendSoldierInformation = animator.GetComponent<SoldierInformation>();
        if(defendSoldierInformation.Enemy != null)
        {
            enemyInformation = defendSoldierInformation.Enemy.transform.root.GetComponent<SoldierInformation>();
        }
        agent.isStopped = true;
        defendSoldierTransform = animator.transform;
        defendSoldierInformation.IsAttacking = true;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        defendSoldierTransform.LookAt(enemyInformation.transform);
        if (!enemyInformation.IsAlive || !SoldierIsCloseEnoughToAttack())
        {
            animator.SetTrigger(Constants.Walk);
        }
        else 
        {
            DecideAttackNextState(animator, stateInfo);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.isStopped = false;
    }

    private void DecideAttackNextState(Animator animator, AnimatorStateInfo stateInfo)
    {
        int randomInt = Random.Range(0, 2);
        if (!stateInfo.IsName(Constants.Attack) && randomInt == 0)
        {
            animator.SetTrigger(Constants.Attack);
        }
        else if (!stateInfo.IsName(Constants.LowAttack) && randomInt == 1)
        {
            animator.SetTrigger(Constants.LowAttack);
        }
        else if (!stateInfo.IsName(Constants.JumpAttack) && randomInt == 2)
        {
            animator.SetTrigger(Constants.JumpAttack);
        }
    }

    private bool SoldierIsCloseEnoughToAttack()
    {
        var distance = Vector3.Distance(defendSoldierTransform.position, defendSoldierInformation.Enemy.transform.position);
        if (distance <= 3)
        {
            return true;
        }
        return false;
    }
}
