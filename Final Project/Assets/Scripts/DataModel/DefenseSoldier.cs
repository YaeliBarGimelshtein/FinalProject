using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseSoldier : Character
{
    public Bar healthBar;
    public SoldierData data;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        data = GetComponent<SoldierData>();
        data.Health = 5;
        if (healthBar != null)
        {
            healthBar.SetMaxBar(data.Health);
        }
        data.IsAttacking = false;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakeAnAttack()
    {
        data.IsAttacking = true;
        if (data.Enemy != null)
        {
            OffenceSoldier enemySoldier = data.Enemy.GetComponent<OffenceSoldier>();
            enemySoldier.TakeAHit();
            Debug.Log("made a hit!");
        }
        data.IsAttacking = false;
    }

    public void TakeAHit()
    {
        data.Health -= 1;
        if (healthBar != null)
        {
            healthBar.SetCurrentBar(data.Health);
        }
        Debug.Log("took a hit! have " + data.Health + " lives");
        if (data.Health == 0)
        {
            Debug.Log("DEAD");
            //Destroy(gameObject);
            animator.SetTrigger("Dead");
        }
        else
        {
            animator.SetTrigger("Defend"); // Soldier took a hit and is now defending himself
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(gameObject.transform.position, 10f);
    }
}
