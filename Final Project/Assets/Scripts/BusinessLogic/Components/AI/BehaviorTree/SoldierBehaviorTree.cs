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

    protected override Node SetUpTree()
    {
        healthBar.SetMaxBar(Constants.MaxHealth);
        Node root = new PatrolTask(agent, walkingPlaces, animator);
        return root;
    }
}
