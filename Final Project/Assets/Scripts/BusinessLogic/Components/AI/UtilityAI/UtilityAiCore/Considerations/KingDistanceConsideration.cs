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

        public override float ScoreConsideration(OffenceSoldierController npc)
        {
            var distance = npc.GetKingDistance();
            if(distance > 100)
            {
                distance = 1;
            }
            else
            {
                distance = distance / 100;
            }
            score = responseCurve.Evaluate(Mathf.Clamp01(distance));
            return score;
        }
    }
}
