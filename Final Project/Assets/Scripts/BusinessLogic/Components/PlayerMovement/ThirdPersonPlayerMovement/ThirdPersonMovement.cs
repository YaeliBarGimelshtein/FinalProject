using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ThirdPersonMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    private AnimatorManager animatorManager;
    private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;
    private float speed = 6f;
    public Transform thirdPersonCamera;
    private AudioSource stepSound;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animatorManager = GetComponent<AnimatorManager>();
        stepSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if(direction.magnitude >= 0.1f)
        {
            float targetAngel = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + thirdPersonCamera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngel, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngel, 0f) * Vector3.forward;
            agent.Move(moveDirection.normalized * Time.deltaTime * speed);
            HandleAnimator(horizontal, vertical);
            if (!stepSound.isPlaying)
            {
                stepSound.Play();
            } 
        }
        else
        {
            HandleAnimator(0, 0);
        }
    }

    private void HandleAnimator(float horizontal, float vertical)
    {
        float moveAmount = Mathf.Clamp01(Mathf.Abs(horizontal) + Mathf.Abs(vertical));
        animatorManager.UpdateAnimatorValues(0, moveAmount);
    }
}
