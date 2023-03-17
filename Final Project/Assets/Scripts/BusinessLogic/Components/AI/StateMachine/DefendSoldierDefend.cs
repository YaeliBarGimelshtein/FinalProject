using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UtilityAI.Core;

public class DefendSoldierDefend : StateMachineBehaviour
{
    private NavMeshAgent agent;
    private SoldierInformation defendSoldierInformation;
    private SoldierController enemy;
    private Transform defendSoldierTransform;
    private DefenseSoldierController defenseSoldierController;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        defendSoldierInformation = animator.GetComponent<SoldierInformation>();
        defenseSoldierController = animator.GetComponent<DefenseSoldierController>();

        if (defendSoldierInformation.Enemy != null)
        {
            enemy = defendSoldierInformation.Enemy.GetComponent<SoldierController>();
        }
        agent.isStopped = true;
        defendSoldierInformation.IsDefending = true;
        defendSoldierTransform = animator.transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        defendSoldierTransform.LookAt(enemy.transform);
        defenseSoldierController.Defend();
        if(!defendSoldierInformation.IsAlive)
        {
            animator.SetTrigger(Constants.Die);
        }
        else if (enemy.information.IsAlive)
        { 
            animator.SetTrigger(Constants.Attack);
        }
        else
        {
            animator.SetTrigger(Constants.Walk);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.isStopped = false;
        defendSoldierInformation.IsDefending = false;
    }
}
