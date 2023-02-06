using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UtilityAI.Core;

namespace UtilityAI.Considerations
{
    [CreateAssetMenu(fileName = "DistanceConsideration", menuName = "UtilityAI/Considerations/DistanceConsideration")]
    public class DistanceConsideration : Consideration
    {
        public override float ScoreConsideration()
        {
            return 0.1f;
            //add logic here
        }
    }
}
