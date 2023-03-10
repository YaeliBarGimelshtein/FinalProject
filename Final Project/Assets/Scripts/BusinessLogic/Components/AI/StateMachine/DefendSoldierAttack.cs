using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DefendSoldierAttack : StateMachineBehaviour
{
    private NavMeshAgent agent;
    private DefenseSoldier soldierData;
    private OffenceSoldier enemy;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        soldierData = animator.GetComponent<DefenseSoldier>();
        if(soldierData.information.GetEnemy() != null)
        {
            enemy = soldierData.information.GetEnemy().GetComponent<OffenceSoldier>();
        }
        agent.isStopped = true;
        soldierData.information.SetIsDefending(false);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!enemy.information.GetIsAlive())
        {
            animator.SetTrigger("Patrol");
        }

        int randomInt = Random.Range(0,3); // generate a random integer

        if (!stateInfo.IsName("Attack") && randomInt == 0)
        {
            animator.SetTrigger("Attack");
        }
        else if (!stateInfo.IsName("Attack Jump Slash") && randomInt == 1)
        {
            animator.SetTrigger("AttackJump");
        }
        else if (!stateInfo.IsName("Attack Impact 1") && randomInt == 2)
        {
            animator.SetTrigger("AttackImpact");
        }
       
        
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.isStopped = false;
    }
}
