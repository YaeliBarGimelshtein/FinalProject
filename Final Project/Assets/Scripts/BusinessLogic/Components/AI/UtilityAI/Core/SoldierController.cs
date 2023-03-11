using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Contract.NPC;
using UnityEngine.AI;

namespace UtilityAI.Core
{
    public class SoldierController : Character, IOfenceSoldierBehaviour
    {
        public AIBrain aiBrain { get; set; }
        public Action[] actionsAvailable;
        public Transform homePosition;
        public GameObject king;
        public Animator animator { get; set; }
        private NavMeshAgent agent;
        public bool finishExecute { get; set; }
        public Bar healthBar;
        public SoldierInformation information;
        private static readonly int enemyBLayerMask = 1 << 3;
        
        // Start is called before the first frame update
        void Start()
        {
            aiBrain = GetComponent<AIBrain>();
            animator = GetComponent<Animator>();
            agent = GetComponent<NavMeshAgent>();
            finishExecute = true;
            information = new SoldierInformation(5);
            if (healthBar != null)
            {
                healthBar.SetMaxBar(information.GetHealth());
            }
        }
        
        // Update is called once per frame
        void Update()
        {
            if(!information.GetIsAlive())
            {
                agent.isStopped = true;
                animator.SetTrigger("Dead");
            }
            else if(aiBrain.finishedDeciding && finishExecute)
            {
                aiBrain.finishedDeciding = false;
                finishExecute = false;
                information.SetIsDefending(false);
                aiBrain.bestAction.Execute(this);
            }
        }

        public void OnFinishedAction()
        {
            aiBrain.DecideBestAction(actionsAvailable);
        }

        #region ConsiderationsWorldData
        public float GetEnemyDistance()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, 10f, enemyBLayerMask);
            if (colliders.Length > 0)
            {
                return GetClosestEnemy(colliders);
            }
            return 10f;
        }

        private float GetClosestEnemy(Collider[] colliders)
        {
            float distance = 10f;
            int closestEnemyIndex = 0;

            for (int i = 0; i < colliders.Length; i++)
            {
                float currentEnemyDistance = Vector3.Distance(transform.position, colliders[i].transform.position);
                if (currentEnemyDistance < distance && enemyIsAlive(colliders[i].gameObject))
                {
                    closestEnemyIndex = i;
                    distance = currentEnemyDistance;
                }
            }
            information.SetEnemy(colliders[closestEnemyIndex].gameObject);
            return distance;
        }

        public float GetSoldierHealth()
        {
            return information.GetHealth();
        }

        public float GetKingDistance()
        {
            return Vector3.Distance(transform.position, king.transform.position);
        }

        private bool enemyIsAlive(GameObject enemyObject)
        {
            Debug.Log("is enemy alive = " + enemyObject.GetComponent<DefenseSoldier>().information.GetIsAlive());
            return enemyObject.GetComponent<DefenseSoldier>().information.GetIsAlive();
        }

        public bool EnemyAttacking()
        {
            if(information.GetEnemy() == null)
            {
                return false;
            }
            return information.GetEnemy().GetComponent<DefenseSoldier>().information.GetIsAttacking();
        }
        #endregion

        #region IOfenceSoldierBehaviour
        public void Fallback()
        {
            Debug.Log("performing best action = fallback");
            animator.SetTrigger("Running");
            agent.destination = homePosition.position;
            agent.speed += 2;
            finishExecute = true;
        }

        public void Defend()
        {
            information.SetIsDefending(true);
            Debug.Log("performing best action = Defend");
            gameObject.transform.LookAt(information.GetEnemy().transform);
            animator.SetTrigger("Defending");
            finishExecute = true;
        }

        public void Attack()
        {
            StartCoroutine(AttackCoroutine());
        }

        public void FollowTheKing()
        {
            StartCoroutine(FollowTheKingCoroutine());
        }

        public void ProtectTheKing()
        {
            Debug.Log("performing best action = ProtectTheKing");
            gameObject.transform.LookAt(information.GetEnemy().transform);
            agent.destination = information.GetEnemy().transform.position;
            finishExecute = true;
        }

        IEnumerator AttackCoroutine()
        {
            Debug.Log("performing best action = Attack");
            animator.SetTrigger("Attacking");
            information.SetIsAttacking(true);
            gameObject.transform.LookAt(information.GetEnemy().transform);
            MakeAnAttack();
            yield return new WaitForSeconds(2f);
            information.SetIsAttacking(false);
            finishExecute = true;
        }

        IEnumerator FollowTheKingCoroutine()
        {
            Debug.Log("performing best action = FollowTheKing");
            gameObject.transform.LookAt(king.transform);
            agent.destination = king.transform.position;
            animator.SetTrigger("Walking");
            yield return new WaitForSeconds(1f);
            finishExecute = true;
        }

        IEnumerator DefendCoroutine()
        {
            Debug.Log("performing best action = Defend");
            information.SetIsDefending(true);
            gameObject.transform.LookAt(information.GetEnemy().transform);
            animator.SetTrigger("Defending");
            yield return new WaitForSeconds(1f);
            information.SetIsDefending(false);
            finishExecute = true;
        }
        #endregion

        #region AttackAndDefendActions
        public void MakeAnAttack()
        {
            if (information.GetEnemy() != null)
            {
                DefenseSoldier enemySoldier = information.GetEnemy().GetComponent<DefenseSoldier>();
                if(enemySoldier.information.GetIsAlive())
                {
                    enemySoldier.TakeAHit();
                    Debug.Log("Offence Soldier: made a hit!");
                }
            }
        }

        public void TakeAHit()
        {
            if(!information.GetIsDefending())
            {
                information.SetHealth(information.GetHealth() - 1);
            }
            
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
        }
        #endregion
    }
}
