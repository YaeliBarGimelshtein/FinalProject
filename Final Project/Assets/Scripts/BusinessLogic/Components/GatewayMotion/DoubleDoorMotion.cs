using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDoorMotion : MonoBehaviour
{
    public Animator animator;
    AudioSource doorSound;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        doorSound = GetComponent<AudioSource>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        animator.SetBool(Constants.DoorMotionOpen, true);
        doorSound.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        animator.SetBool(Constants.DoorMotionOpen, false);
    }
}
