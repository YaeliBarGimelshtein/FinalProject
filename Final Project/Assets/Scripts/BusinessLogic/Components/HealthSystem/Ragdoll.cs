using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    Rigidbody[] rigitBodies;
    Animator animator;
    GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        rigitBodies = GetComponentsInChildren<Rigidbody>();
        animator = GetComponent<Animator>();
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
    }
}
