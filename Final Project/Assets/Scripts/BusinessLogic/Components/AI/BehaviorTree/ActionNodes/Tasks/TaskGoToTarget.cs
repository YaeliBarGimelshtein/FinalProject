using BehaviorTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TaskGoToTarget : Node
{
    private NavMeshAgent agent;

    public TaskGoToTarget(NavMeshAgent agent)
    {
        this.agent = agent;
    }

    public override NodeState Evaluate()
    {
        Transform target = (Transform)GetData("target");
        if (!agent.pathPending && agent.remainingDistance < Constants.DefenceSoldierWalkingDistance)
        {
            agent.SetDestination(target.position);
        }

        state = NodeState.RUNNING;
        return state;
    }
}
