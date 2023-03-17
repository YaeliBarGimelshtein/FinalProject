using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DefendSoldierRunToEnemy : StateMachineBehaviour
{
    private NavMeshAgent agent;
    private Transform defendSoldierTransform;
    private SoldierInformation defendSoldierInformation;
    private int tries;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        defendSoldierTransform = animator.GetComponent<Transform>();
        defendSoldierInformation = animator.GetComponent<SoldierInformation>();
        agent.speed += 2;
        tries = 0;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(SoldierIsCloseEnoughToAttack())
        {
            animator.SetTrigger(Constants.Attack);
        }
        else if(tries > 100)
        { 
            animator.SetTrigger(Constants.Walk);
        }
        else
        {
            tries++;
        }
    }
    
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.speed -= 2;
    }

    private bool SoldierIsCloseEnoughToAttack()
    {
        var distance = Vector3.Distance(defendSoldierTransform.position, defendSoldierInformation.Enemy.transform.position);
        if(distance <= 3)
        {
            return true;
        }
        return false;
    }
}
