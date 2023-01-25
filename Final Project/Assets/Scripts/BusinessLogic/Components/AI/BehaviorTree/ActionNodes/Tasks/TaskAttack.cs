using BehaviorTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskAttack : Node
{
    private Transform lastTarget;
    private Enemy enemy;
    private Animator animator;
    private readonly float attackTime = 1f;
    private float attackCounter = 0f;

    public TaskAttack(Transform transform)
    {
        animator = transform.GetComponent<Animator>();
    }

    public override NodeState Evaluate()
    {
        Transform target = (Transform)GetData("target");
        if(target != lastTarget)
        {
            enemy = target.GetComponent<Enemy>();
            lastTarget = target;
        }

        attackCounter += Time.deltaTime;
        if(attackCounter >= attackTime)
        {
            bool enemyDead = enemy.TakeHit();
            if(enemyDead)
            {
                ClearData("target");
                animator.SetTrigger("Walking");
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
