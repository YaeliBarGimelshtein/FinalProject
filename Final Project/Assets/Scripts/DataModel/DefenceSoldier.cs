using Assets.Scripts.Contract.NPC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DefenceSoldier : Soldier, IDefenceSoldierBehaviour
{
    private Animator animator;
    private NavMeshAgent agent;
    private int destinationPoint = 0;
    public Transform[] partolPlaces;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = true;
        agent.autoBraking = false;
        Patrol();
    }

    // Update is called once per frame
    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            Patrol();
        }
    }

    public void Patrol()
    {
        // Returns if no points have been set up
        if (partolPlaces.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = partolPlaces[destinationPoint].position;
        
        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destinationPoint = (destinationPoint + 1) % partolPlaces.Length;
    }
}
