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

        public override float ScoreConsideration(OffenceSoldierController npc)
        {
            var health = npc.GetSoldierHealth() / Constants.MaxHealth;
            score = responseCurve.Evaluate(Mathf.Clamp01(health));
            Debug.Log("HealthConsideration score is: " + score);
            return score;
        }
    }
}
