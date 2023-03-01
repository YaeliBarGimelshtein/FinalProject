using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Contract.NPC;

namespace UtilityAI.Core
{
    public class SoldierController : Character, IOfenceSoldierBehaviour
    {
        public DefenseSoldier soldierData { get; protected set; }
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
            soldierData = GetComponent<DefenseSoldier>();
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
                if (currentEnemyDistance < distance)
                {
                    closestEnemyIndex = i;
                    distance = currentEnemyDistance;
                }
            }
            soldierData.data.Enemy = colliders[closestEnemyIndex].gameObject;
            return distance;
        }

        public float GetSoldierHealth()
        {
            return soldierData.data.Health;
        }

        public float GetKingDistance()
        {
            return Vector3.Distance(transform.position, king.transform.position);
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
            gameObject.transform.LookAt(soldierData.data.Enemy.transform);
            animator.SetTrigger("Defend");
            soldierData.TakeAHit();
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
            gameObject.transform.LookAt(soldierData.data.Enemy.transform);
            mover.MoveTo(soldierData.data.Enemy.transform.position);
            finishExecute = true;
        }

        IEnumerator FollowTheKingCoroutine()
        {
            gameObject.transform.LookAt(king.transform);
            animator.SetTrigger("Walking");
            yield return new WaitForSeconds(2);
            mover.MoveTo(king.transform.position);
            finishExecute = true;
        }

        IEnumerator AttackCoroutine()
        {
            if(soldierData.data.Enemy != null)
            {
                animator.SetTrigger("Attacking");
                yield return new WaitForSeconds(2);
                soldierData.MakeAnAttack();
            }
            finishExecute = true;
        }
        #endregion
    }
}
