using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEnabler : MonoBehaviour
{
    private Animator animator;
    public GameObject weapon;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("attack");
        }
    }

    void EnableWeapon()
    {
        weapon.GetComponent<Collider>().enabled = true;
    }

    void DisableWeapon()
    {
        weapon.GetComponent<Collider>().enabled = false;
    }
}
