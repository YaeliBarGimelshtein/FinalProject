using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateMotion : MonoBehaviour
{
    Animator animator;
    AudioSource doorSound;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        doorSound = GetComponent<AudioSource>();
    }
   
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        animator.SetBool("Gate open", true);
        doorSound.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("Gate open", false);
    }
}
