using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DefendSoldierRunToEnemy : StateMachineBehaviour
{
    private NavMeshAgent agent;
    private Transform soldier;
    private DefenseSoldier soldierData;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        soldier = animator.GetComponent<Transform>();
        soldierData = animator.GetComponent<DefenseSoldier>();

        agent.speed += 2;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(SoldierIsCloseEnoughToAttack())
        {
            animator.SetTrigger("Attack");
        }
    }
    
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }

    private bool SoldierIsCloseEnoughToAttack()
    {
        if(soldierData != null)
        {
            var distance = Vector3.Distance(soldier.position, soldierData.data.Enemy.transform.position);
            if(distance <= 3)
            {
                return true;
            }
        }
        return false;
    }
}
