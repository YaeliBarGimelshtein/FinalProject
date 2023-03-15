using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovementScript : MonoBehaviour
{
    public CharacterController controller;
    public Transform groundCheck;
    public float speed = 4f;
    public float gravity = -9.81f;
    public float groundDistance = 0.4f;
    public float jumpHeight = 3f;
    public LayerMask groundMask;
    private AudioSource stepSound;
    private Vector3 velocity;
    private bool isGrounded;
 

    // Start is called before the first frame update
    void Start()
    {
        stepSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        PlayStepsSound(move);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void PlayStepsSound(Vector3 move)
    {
        if (Mathf.Abs(move.x) > 0.1 || Mathf.Abs(move.z) > 0.1) // we are moving
            if (!stepSound.isPlaying)
                stepSound.Play();
    }
  
}
