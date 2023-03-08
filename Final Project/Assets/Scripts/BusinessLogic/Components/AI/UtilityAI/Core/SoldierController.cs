using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Contract.NPC;

namespace UtilityAI.Core
{
    public class SoldierController : Character, IOfenceSoldierBehaviour
    {
        public OffenceSoldier soldierData { get; protected set; }
        public MoveController mover { get; set; }
        public AIBrain aiBrain { get; set; }
        public Action[] actionsAvailable;
        public Transform homePosition;
        public GameObject king;
        public Animator animator { get; set; }
        public bool finishExecute { get; set; }
        private static readonly int enemyBLayerMask = 1 << 3;
        
        // Start is called before the first frame update
        void Start()
        {
            mover = GetComponent<MoveController>();
            aiBrain = GetComponent<AIBrain>();
            soldierData = GetComponent<OffenceSoldier>();
            animator = GetComponent<Animator>();
            finishExecute = true;
        }
        
        // Update is called once per frame
        void Update()
        {
            if(aiBrain.finishedDeciding && finishExecute)
            {
                aiBrain.finishedDeciding = false;
                finishExecute = false;
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
            soldierData.information.SetEnemy(colliders[closestEnemyIndex].gameObject);
            return distance;
        }

        public float GetSoldierHealth()
        {
            return soldierData.information.GetHealth();
        }

        public float GetKingDistance()
        {
            return Vector3.Distance(transform.position, king.transform.position);
        }

        private bool enemyIsAlive(GameObject enemyObject)
        {
            Debug.Log("is enemy dead = " + enemyObject.GetComponent<DefenseSoldier>().information.GetIsAlive());
            return enemyObject.GetComponent<DefenseSoldier>().information.GetIsAlive();
        }
        #endregion

        #region IOfenceSoldierBehaviour
        public void Fallback()
        {
            animator.SetTrigger("Walking");
            mover.MoveTo(homePosition.position);
        }

        public void Defend()
        {
            gameObject.transform.LookAt(soldierData.information.GetEnemy().transform);
            animator.SetTrigger("Defending");
            soldierData.TakeAHit();
        }

        public void Attack()
        {
            if (soldierData.information.GetEnemy() != null)
            {
                animator.SetTrigger("Attacking");
                soldierData.MakeAnAttack();
            }
            finishExecute = true;
        }

        public void FollowTheKing()
        {
            gameObject.transform.LookAt(king.transform);
            animator.SetTrigger("Walking");
            mover.MoveTo(king.transform.position);
            finishExecute = true;
        }

        public void ProtectTheKing()
        {
            gameObject.transform.LookAt(soldierData.information.GetEnemy().transform);
            mover.MoveTo(soldierData.information.GetEnemy().transform.position);
            finishExecute = true;
        }
        #endregion
    }
}
