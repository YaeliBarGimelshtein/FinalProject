using Assets.Scripts.Contract.NPC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DefenceSoldier : Soldier, IDefenceSoldierBehaviour
{
    private Animator animator;
    private UnityEngine.AI.NavMeshAgent agent;
    private int destinationPoint = 0;
    public Transform[] walkingPlaces;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.enabled = true;
        agent.autoBraking = false;
        Patrol();
    }

    // Update is called once per frame
    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < Constants.WalkingDistance)
        {
            Patrol();
        }
    }

    public void Patrol()
    {
        // Returns if no points have been set up
        if (walkingPlaces.Length == 0)
        {
            return;
        }

        // Set the agent to go to the currently selected destination.
        agent.SetDestination(walkingPlaces[destinationPoint].position);

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destinationPoint = (destinationPoint + 1) % walkingPlaces.Length;
    }
}
