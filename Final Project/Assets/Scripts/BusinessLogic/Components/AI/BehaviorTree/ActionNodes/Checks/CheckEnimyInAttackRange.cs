using BehaviorTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEnimyInAttackRange : Node
{
    private static readonly int enemyLayerMask = 1 << 3;
    private Transform transform;
    private Animator animator;

    public CheckEnimyInAttackRange(Transform transform, Animator animator)
    {
        this.transform = transform;
        this.animator = animator;
    }

    public override NodeState Evaluate()
    {
        Transform target = (Transform)GetData("target");
        if(target == null)
        {
            state = NodeState.FAILURE;
            return state;
        }

        if(Vector3.Distance(transform.position, target.position) <= SoldierBehaviorTree.enemyAttackRange)
        {
            animator.SetTrigger("Attacking");
            state = NodeState.SUCCESS;
            return state;
        }

        state = NodeState.FAILURE;
        return state;
    }
}
