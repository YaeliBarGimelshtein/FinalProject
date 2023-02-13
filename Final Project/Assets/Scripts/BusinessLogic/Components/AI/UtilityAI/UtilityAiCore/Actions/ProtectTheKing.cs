using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UtilityAI.Core;

namespace UtilityAI.Actions
{
    [CreateAssetMenu(fileName = "ProtectTheKing", menuName = "UtilityAI/Actions/ProtectTheKing")]
    public class ProtectTheKing : Action
    {
        public override void Execute(SoldierController npc)
        {
            npc.ProtectTheKing();
            npc.OnFinishedAction();
        }
    }
}
