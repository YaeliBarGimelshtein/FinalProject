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
        StartCoroutine(AttackCoroutine());
    }

    IEnumerator AttackCoroutine()
    {
        Debug.Log("Defence soldier: starting AttackCoroutine");
        SoldierController enemySoldier = information.GetEnemy().GetComponent<SoldierController>();
        yield return new WaitForSeconds(2f);
        if(enemySoldier.information.GetIsAlive())
        {
            enemySoldier.TakeAHit();
            Debug.Log("Defence soldier: made a hit!");
        }
        information.SetIsAttacking(false);
        Debug.Log("Defence soldier: finished AttackCoroutine");
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
            animator.SetTrigger("Defend");
        }
        
        Debug.Log("Defence soldier: took a hit! have " + information.GetHealth() + " lives");
        if (information.GetHealth() == 0)
        {
            Debug.Log("Defence soldier: DEAD");
            //Destroy(gameObject);
            animator.SetTrigger("Dead");
            agent.isStopped = true;
        }
    }

    public void Defend()
    {
        StartCoroutine(DefendCoroutine());
    }

    IEnumerator DefendCoroutine()
    {
        Debug.Log("Defence soldier: starting DefendCoroutine");
        yield return new WaitForSeconds(2f);
        information.SetIsDefending(false);
        Debug.Log("Defence soldier: finished DefendCoroutine");
    }
}
