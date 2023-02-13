using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UtilityAI.Core
{
    public class AIBrain : MonoBehaviour
    {
        public Action bestAction { get; set; }
        private SoldierController npc;
        public bool finishedDeciding { get; set; }

        // Start is called before the first frame update
        void Start()
        {
            npc = GetComponent<SoldierController>();
        }

        // Update is called once per frame
        void Update()
        {
            if(bestAction == null)
            {
                DecideBestAction(npc.actionsAvailable);
            }
        }

        /// <summary>
        /// Loops through all the considerations of an action, score them,
        /// average them to get an overall action score
        /// </summary>
        /// <param name="action"></param>
        public float ScoreAction(Action action)
        {
            float score = 1f;
            for (int i = 0; i < action.considerations.Length; i++)
            {
                float considerationScore = action.considerations[i].ScoreConsideration(npc);
                score *= considerationScore;

                if(score == 0)
                {
                    action.score = 0;
                    return score;
                }
            }

            //averaging scheme of overall score developed by Dave Mark (normalization)
            float originalScore = score;
            float modificationFactor = 1 - (1 / action.considerations.Length);
            float makeupValue = (1 - originalScore) * modificationFactor;
            action.score = originalScore + (makeupValue * originalScore);

            return action.score;
        }

        /// <summary>
        /// Loops through all the available actions and gives the highest scoring action
        /// </summary>
        /// <param name="actionsAvailable"></param>
        public void DecideBestAction(Action[] actionsAvailable)
        {
            float score = 0f;
            int bestActionIndex = 0;

            for (int i = 0; i < actionsAvailable.Length; i++)
            {
                if(ScoreAction(actionsAvailable[i]) > score)
                {
                    bestActionIndex = i;
                    score = actionsAvailable[i].score;
                }
            }

            bestAction = actionsAvailable[bestActionIndex];
            finishedDeciding = true;
            Debug.Log("best action = " + bestAction);
        }
    }
}
