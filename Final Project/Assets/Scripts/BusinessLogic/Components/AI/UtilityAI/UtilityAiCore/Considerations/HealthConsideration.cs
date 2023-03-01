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
            var healthBefore = npc.GetSoldierHealth();
            var health = healthBefore / 5;
            score = responseCurve.Evaluate(Mathf.Clamp01(health));
            return score;
        }
    }
}
