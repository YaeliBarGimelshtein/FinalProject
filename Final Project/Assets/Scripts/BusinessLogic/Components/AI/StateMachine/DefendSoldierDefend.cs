using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UtilityAI.Core;

public class DefendSoldierDefend : StateMachineBehaviour
{
    private NavMeshAgent agent;
    private DefenseSoldier soldierData;
    private SoldierController enemy;
    private Transform defendSoldierTransform;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        soldierData = animator.GetComponent<DefenseSoldier>();
        if (soldierData.information.GetEnemy() != null)
        {
            enemy = soldierData.information.GetEnemy().GetComponent<SoldierController>();
        }
        agent.isStopped = true;
        soldierData.information.SetIsDefending(true);
        defendSoldierTransform = animator.transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        defendSoldierTransform.LookAt(enemy.transform);
        soldierData.Defend();
        if(!soldierData.information.GetIsAlive())
        {
            animator.SetTrigger("Dead");
        }
        else if (enemy.information.GetIsAlive())
        { 
            animator.SetTrigger("Attack");
        }
        else
        {
            animator.SetTrigger("Patrol");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.isStopped = false;
        soldierData.information.SetIsDefending(false);
    }
}
