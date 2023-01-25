using BehaviorTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolTask : Node
{
    private NavMeshAgent agent;
    private Transform[] walkingPlaces;
    private int destinationPoint = 0;
    private Animator animator;

    public PatrolTask(NavMeshAgent agent, Transform[] walkingPlaces, Animator animator)
    {
        this.agent = agent;
        this.walkingPlaces = walkingPlaces;
        this.animator = animator;
    }

    public override NodeState Evaluate()
    {
        animator.SetTrigger("Walking");
        if (!agent.pathPending && agent.remainingDistance < Constants.DefenceSoldierWalkingDistance)
        {
            // Returns if no points have been set up
            if (walkingPlaces.Length == 0)
            {
                state = NodeState.FAILURE;
                return state;
            }

            // Set the agent to go to the currently selected destination.
            agent.SetDestination(walkingPlaces[destinationPoint].position);

            // Choose the next point in the array as the destination,
            // cycling to the start if necessary.
            destinationPoint = (destinationPoint + 1) % walkingPlaces.Length;
        }
        
        state = NodeState.RUNNING;
        return state;
    }

}
