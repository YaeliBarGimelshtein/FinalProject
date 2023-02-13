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
            score = responseCurve.Evaluate(Mathf.Clamp01(npc.GetEnemyDistance()));
            return score;
        }
    }
}
