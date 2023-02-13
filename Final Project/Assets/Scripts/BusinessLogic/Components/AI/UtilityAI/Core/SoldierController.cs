using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Contract.NPC;

namespace UtilityAI.Core
{
    public class SoldierController : Character, IOfenceSoldierBehaviour
    {
        public Soldier soldierData { get; protected set; }
        public MoveController mover { get; set; }
        public AIBrain aiBrain { get; set; }
        public Action[] actionsAvailable;
        public Transform homePosition;
        public GameObject king;
        public Animator animator { get; set; }
        private static readonly int enemyBLayerMask = 1 << 3;
        
        // Start is called before the first frame update
        void Start()
        {
            mover = GetComponent<MoveController>();
            aiBrain = GetComponent<AIBrain>();
            soldierData = GetComponent<Soldier>();
            animator = GetComponent<Animator>();
        }
        
        // Update is called once per frame
        void Update()
        {
            if(aiBrain.finishedDeciding)
            {
                aiBrain.finishedDeciding = false;
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
            Collider[] colliders = Physics.OverlapSphere(transform.position, 1f, enemyBLayerMask);
            if (colliders.Length > 0)
            {
                return GetClosestEnemy(colliders);
            }
            return -1f;
        }

        private float GetClosestEnemy(Collider[] colliders)
        {
            float distance = 0f;
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
            soldierData.Enemy = colliders[closestEnemyIndex].gameObject;
            return distance;
        }

        public float GetSoldierHealth()
        {
            return soldierData.Health;
        }
        #endregion

        #region IOfenceSoldierBehaviour
        public void Fallback()
        {
            //Debug.Log("I Fallback once");

            //logic to Fallback
            mover.MoveTo(homePosition.position);

            //decide new action when finished
            OnFinishedAction();
        }

        public void Defend()
        {
            gameObject.transform.LookAt(soldierData.Enemy.transform);
            animator.SetTrigger("Defend");
            soldierData.TakeAHit();
        }

        public void Attack()
        {
            gameObject.transform.LookAt(soldierData.Enemy.transform);
            animator.SetTrigger("Attack");
            soldierData.MakeAnAttack();
        }

        public void FollowTheKing()
        {
            gameObject.transform.LookAt(king.transform);
            mover.MoveTo(king.transform.position);
        }

        public void ProtectTheKing()
        {
            gameObject.transform.LookAt(soldierData.Enemy.transform);
            mover.MoveTo(soldierData.Enemy.transform.position);
        }
        #endregion
    }
}
