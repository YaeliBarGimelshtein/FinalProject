using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UtilityAI.Core;

namespace UtilityAI.Considerations
{
    [CreateAssetMenu(fileName = "DistanceConsideration", menuName = "UtilityAI/Considerations/DistanceConsideration")]
    public class DistanceConsideration : Consideration
    {
        [SerializeField] private AnimationCurve responseCurve;

        public override float ScoreConsideration(SoldierController npc)
        {
            score = responseCurve.Evaluate(Mathf.Clamp01(npc.GetEnemyDistance()));
            return score;
            //add logic here
        }
    }
}
