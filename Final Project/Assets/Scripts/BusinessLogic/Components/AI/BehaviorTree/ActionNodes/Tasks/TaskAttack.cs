using BehaviorTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskAttack : Node
{
    private Transform lastTarget;
    private Enemy enemy;
    private Animator animator;
    private float attackTime = 2f;
    private float attackCounter = 0f;

    public TaskAttack(Transform transform)
    {
        animator = transform.GetComponent<Animator>();
    }

    public override NodeState Evaluate()
    {
        Transform target = (Transform)GetData("target");
        if (target != lastTarget)
        {
            enemy = target.GetComponent<Enemy>();
            lastTarget = target;
        }

        attackCounter += Time.deltaTime;
        if (attackCounter >= attackTime)
        {
            bool enemyIsDead = enemy.TakeHit();
            if (enemyIsDead)
            {
                animator.SetTrigger("Walking");
                ClearData("target");
            }
            else
            {
                attackCounter = 0f;
            }
        }

        state = NodeState.RUNNING;
        return state;
    }
}
