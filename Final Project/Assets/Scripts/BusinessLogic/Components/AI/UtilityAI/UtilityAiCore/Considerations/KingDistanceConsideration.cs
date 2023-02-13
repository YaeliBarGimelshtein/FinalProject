using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UtilityAI.Core;

namespace UtilityAI.Considerations
{
    [CreateAssetMenu(fileName = "KingDistanceConsideration", menuName = "UtilityAI/Considerations/KingDistanceConsideration")]
    public class KingDistanceConsideration : Consideration
    {
        [SerializeField] private AnimationCurve responseCurve;

        public override float ScoreConsideration(SoldierController npc)
        {
            score = responseCurve.Evaluate(Mathf.Clamp01(npc.GetKingDistance()/100));
            return score;
        }
    }
}
