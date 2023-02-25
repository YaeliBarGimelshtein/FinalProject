using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DefendSoldierAttack : StateMachineBehaviour
{
    private NavMeshAgent agent;
    private Soldier soldierData;
    private Soldier enemy;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        soldierData = animator.GetComponent<Soldier>();
        if(soldierData.Enemy != null)
        {
            enemy = soldierData.Enemy.GetComponent<Soldier>();
        }
        agent.isStopped = true;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(soldierData.Health == 0)
        {
            animator.SetTrigger("Die");
        }
        if(enemy.isAttacking)
        {
            animator.SetTrigger("Defend");
        }

        if(enemy.Health == 0)
        {
            animator.SetTrigger("Patrol");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.isStopped = false;
        agent.speed -= 2;
    }
}
