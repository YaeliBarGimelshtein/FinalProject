using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffenceSoldier : Character
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
            DefenseSoldier enemySoldier = information.GetEnemy().GetComponent<DefenseSoldier>();
            enemySoldier.TakeAHit();
            Debug.Log("Offence Soldier: made a hit!");
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
        Debug.Log("Offence Soldier: took a hit! have " + information.GetHealth() + " lives");
        if (information.GetHealth() == 0)
        {
            Debug.Log("Offence Soldier: DEAD");
            //Destroy(gameObject);
            animator.SetTrigger("Dead");
        }
        else
        {
            animator.SetTrigger("Defending"); // Soldier took a hit and is now defending himself
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(gameObject.transform.position, 10f);
    }
}
