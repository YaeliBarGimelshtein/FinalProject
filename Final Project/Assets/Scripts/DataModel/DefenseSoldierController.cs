using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UtilityAI.Core;

public class DefenseSoldierController : Character
{
    public SoldierInformation information;
    private Animator animator;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
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
        SoldierController enemySoldier = information.Enemy.GetComponent<SoldierController>();
        yield return new WaitForSeconds(2f);
        if(enemySoldier.information.IsAlive)
        {
            enemySoldier.TakeAHit();
            Debug.Log("Defence soldier: made a hit!");
        }
        information.IsAttacking = false;
        Debug.Log("Defence soldier: finished AttackCoroutine");
    }

    public void TakeAHit()
    {
        if (!information.IsDefending)
        {
            information.Health -= 1;
            animator.SetTrigger(Constants.Defend);
        }
        
        Debug.Log("Defence soldier: took a hit! have " + information.Health + " lives");
        if (information.Health == 0)
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
        information.IsDefending = false;
        Debug.Log("Defence soldier: finished DefendCoroutine");
    }
}
