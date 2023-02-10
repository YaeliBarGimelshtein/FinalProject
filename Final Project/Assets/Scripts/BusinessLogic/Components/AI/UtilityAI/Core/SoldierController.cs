using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UtilityAI.Core
{
    public class SoldierController : Soldier
    {
        public MoveController mover { get; set; }
        public AIBrain aiBrain { get; set; }
        public Bar healthBar;
        public Action[] actionsAvailable;
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

        public void DoFallback(int time)
        {
            StartCoroutine(FallbackCoroutine(time));
        }

        IEnumerator FallbackCoroutine(int time)
        {
            int counter = time;
            while (counter > 0)
            {
                yield return new WaitForSeconds(1);
                counter--;
            }
            Debug.Log("I Fallback once");

            //logic to Fallback

            //decide new action when finished
            OnFinishedAction();
        }

        public void OnFinishedAction()
        {
            aiBrain.DecideBestAction(actionsAvailable);
        }

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

        public void Defend()
        {
            //activate defend animation
            //reduce health
        }
    }
}
