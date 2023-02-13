using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UtilityAI.Core;

namespace UtilityAI.Considerations
{
    [CreateAssetMenu(fileName = "EnemyDistanceConsideration", menuName = "UtilityAI/Considerations/EnemyDistanceConsideration")]
    public class EnemyDistanceConsideration : Consideration
    {
        [SerializeField] private AnimationCurve responseCurve;

        public override float ScoreConsideration(SoldierController npc)
        {
            var distanceBefore = npc.GetEnemyDistance();
            var distance = distanceBefore / 10;
            score = responseCurve.Evaluate(Mathf.Clamp01(distance));
            //Debug.Log("distance before /10 is " + distanceBefore + "after is " + distance + "and score is " + score);
            return score;
        }
    }
}
