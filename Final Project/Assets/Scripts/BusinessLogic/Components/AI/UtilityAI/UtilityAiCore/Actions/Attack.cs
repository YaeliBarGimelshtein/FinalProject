using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UtilityAI.Core;

namespace UtilityAI.Actions
{
    [CreateAssetMenu(fileName = "Attack", menuName = "UtilityAI/Actions/Attack")]
    public class Attack : Action
    {
        public override void Execute(SoldierController npc)
        {
            npc.Attack();
            npc.OnFinishedAction();
        }
    }
}
