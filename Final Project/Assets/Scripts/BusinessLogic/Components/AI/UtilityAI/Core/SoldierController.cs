using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Contract.NPC;

namespace UtilityAI.Core
{
    public class SoldierController : Soldier, IOfenceSoldierBehaviour
    {
        public MoveController mover { get; set; }
        public AIBrain aiBrain { get; set; }
        public Bar healthBar;
        public Action[] actionsAvailable;
        public Transform homePosition;
        private static readonly int enemyBLayerMask = 1 << 3;
        
        // Start is called before the first frame update
        void Start()
        {
            mover = GetComponent<MoveController>();
            aiBrain = GetComponent<AIBrain>();
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
            Collider[] colliders = Physics.OverlapSphere(transform.position, 30f, enemyBLayerMask);
            if (colliders.Length > 0)
            {
                return GetClosestEnemy(colliders);
            }
            return 0f;
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
            return distance;
        }

        public float GetSoldierHealth()
        {
            return Helath;
        }
        #endregion

        #region IOfenceSoldierBehaviour
        public void Fallback()
        {
            Debug.Log("I Fallback once");

            //logic to Fallback
            mover.MoveTo(homePosition.position);

            //decide new action when finished
            OnFinishedAction();
        }

        public void Defend()
        {
            //activate defend animation
            //reduce health
        }

        public void Attack()
        {
            //activate attack animation
            //reduce enemy health
        }
        #endregion
    }
}
