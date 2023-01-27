using BehaviorTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEnemyInSight : Node
{
    private static readonly int enemyBLayerMask = 1 << 3;
    private Transform transform;
    private Animator animator;

    public CheckEnemyInSight(Transform transform, Animator animator)
    {
        this.transform = transform;
        this.animator = animator;
    }

    public override NodeState Evaluate()
    {
        object target = GetData("target");
        if(target == null)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, SoldierBehaviorTree.enemyRange, enemyBLayerMask);
            if(colliders.Length > 0)
            {
                parent.parent.SetData("target", colliders[0].transform); //saves the first enemy in sight in the root
                animator.SetTrigger("Walking");
                state = NodeState.SUCCESS;
                return state;
            }

            state = NodeState.FAILURE;
            return state;
        }

        state = NodeState.SUCCESS;
        return state;
    }
}
