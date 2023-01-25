using System.Collections;
using System.Collections.Generic;
using BehaviorTree;

public class SoldierBehaviorTree : Tree
{
    public UnityEngine.Transform[] walkingPlaces;
    public UnityEngine.AI.NavMeshAgent agent;
    public UnityEngine.Animator animator;
    public Bar healthBar;
    public static float speed = 2f;
    public static float enemyRange = 6f;
    public static float enemyAttackRange = 2f;

    protected override Node SetUpTree()
    {
        healthBar.SetMaxBar(Constants.MaxHealth);
        Node root = new Selector(new List<Node>
        {
            new Sequence(new List<Node>
            {
                new CheckEnimyInAttackRange(transform, animator),
                new TaskAttack(transform)
            }),
            new Sequence(new List<Node>
            {
                new CheckEnemyInSight(transform, animator),
                new TaskGoToTarget(agent)
            }),
            new TaskPatrol(agent, walkingPlaces, animator),
        });
        return root;
    }
}
