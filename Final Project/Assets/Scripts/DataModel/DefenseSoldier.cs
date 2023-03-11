using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UtilityAI.Core;

public class DefenseSoldier : Character
{
    public Bar healthBar;
    public SoldierInformation information;
    private Animator animator;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        information = new SoldierInformation(5);

        if (healthBar != null)
        {
            healthBar.SetMaxBar(information.GetHealth());
        }
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
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
            SoldierController enemySoldier = information.GetEnemy().GetComponent<SoldierController>();
            enemySoldier.TakeAHit();
            Debug.Log("Defence soldier: made a hit!");
        }
        information.SetIsAttacking(false);
    }

    public void TakeAHit()
    {
        if (!information.GetIsDefending())
        {
            information.SetHealth(information.GetHealth() - 1);
            if (healthBar != null)
            {
                healthBar.SetCurrentBar(information.GetHealth());
            }
            Debug.Log("Defence soldier: took a hit! have " + information.GetHealth() + " lives");
            if (information.GetHealth() == 0)
            {
                Debug.Log("Defence soldier: DEAD");
                //Destroy(gameObject);
                animator.SetTrigger("Dead");
                agent.isStopped = true;
            }
            else
            {
                animator.SetTrigger("Defend"); // Soldier took a hit and is now defending himself
            }
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(gameObject.transform.position, 10f);
    }
}
