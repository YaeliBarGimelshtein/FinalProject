using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollForThirdPersonShooter : MonoBehaviour
{
    Rigidbody[] rigitBodies;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigitBodies = GetComponentsInChildren<Rigidbody>();
        animator = GetComponent<Animator>();
        DeactivateRagdoll();
    }

    public void DeactivateRagdoll()
    {
        foreach (var rigidBody in rigitBodies)
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
    }
}
