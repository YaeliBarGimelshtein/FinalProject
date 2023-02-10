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

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        walkingPlaces = GameObject.FindGameObjectsWithTag("CastleBPatrol").Select(go => go.transform).ToList();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!agent.pathPending && agent.remainingDistance < Constants.DefenceSoldierWalkingDistance)
        {
            Patrol();
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

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
}
