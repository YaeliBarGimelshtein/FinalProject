using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UtilityAI.Core;

namespace UtilityAI.Actions
{
    [CreateAssetMenu(fileName = "Fallback", menuName = "UtilityAI/Actions/Fallback")]
    public class Fallback : Action
    {
        public override void Execute(OffenceSoldierController npc)
        {
            npc.Fallback();
            npc.OnFinishedAction();
        }
    }
}
