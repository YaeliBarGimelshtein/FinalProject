using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ragdoll : MonoBehaviour
{
    Rigidbody[] rigitBodies;
    Animator animator;
    GameObject canvas;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        rigitBodies = GetComponentsInChildren<Rigidbody>();
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        canvas = gameObject.transform.GetChild(5).gameObject;
        DeactivateRagdoll();
    }

    public void DeactivateRagdoll()
    {
        foreach(var rigidBody in rigitBodies)
        {
            rigidBody.isKinematic = true;
        }
        animator.enabled = true;
    }

    public void ActivateRagdoll()
    {
        foreach (var rigidBody in rigitBodies)
        {
            rigidBody.isKinematic = false;
        }
        animator.enabled = false;
        canvas.SetActive(false);
        agent.isStopped = true;
    }
}
