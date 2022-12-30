using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGatesMotion : MonoBehaviour
{
    private Animator animator;
    private AudioSource doorSound;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        doorSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        animator.SetBool(Constants.GateMotionOpen, true);
        doorSound.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        animator.SetBool(Constants.GateMotionOpen, false);
    }
}
