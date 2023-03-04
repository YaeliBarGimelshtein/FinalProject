using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseSoldier : Character
{
    public Bar healthBar;
    public SoldierInformation information;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        information = new SoldierInformation(5);

        if (healthBar != null)
        {
            healthBar.SetMaxBar(information.GetHealth());
        }

        animator = GetComponent<Animator>();

        Debug.Log("health is " + information.GetHealth());
        Debug.Log("data.IsAttacking is " + information.GetIsAttacking());
        if(information.GetEnemy() == null)
            Debug.Log("data.enemy is null");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakeAnAttack()
    {
        information.SetIsAttacking(true);
        if (information.GetEnemy() != null)
        {
            OffenceSoldier enemySoldier = information.GetEnemy().GetComponent<OffenceSoldier>();
            enemySoldier.TakeAHit();
            Debug.Log("made a hit!");
        }
        information.SetIsAttacking(false);
    }

    public void TakeAHit()
    {
        information.SetHealth(information.GetHealth() - 1);
        if (healthBar != null)
        {
            healthBar.SetCurrentBar(information.GetHealth());
        }
        Debug.Log("took a hit! have " + information.GetHealth() + " lives");
        if (information.GetHealth() == 0)
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
