using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UtilityAI.Core;

namespace UtilityAI.Considerations
{
    [CreateAssetMenu(fileName = "HealthConsideration", menuName = "UtilityAI/Considerations/HealthConsideration")]
    public class HealthConsideration : Consideration
    {
        public override float ScoreConsideration()
        {
            return 0.9f;
            //add logic here
        }
    }
}
