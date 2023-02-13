using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UtilityAI.Core;

namespace UtilityAI.Considerations
{
    [CreateAssetMenu(fileName = "HealthConsideration", menuName = "UtilityAI/Considerations/HealthConsideration")]
    public class HealthConsideration : Consideration
    {
        [SerializeField] private AnimationCurve responseCurve;

        public override float ScoreConsideration(SoldierController npc)
        {
            score = responseCurve.Evaluate(Mathf.Clamp01(npc.GetSoldierHealth()/5));
            return score;
        }
    }
}
