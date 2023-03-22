using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UtilityAI.Core;

namespace UtilityAI.Actions
{
    [CreateAssetMenu(fileName = "Attack", menuName = "UtilityAI/Actions/Attack")]
    public class Attack : Action
    {
        public override void Execute(OffenceSoldierController npc)
        {
            npc.Attack();
            npc.OnFinishedAction();
        }
    }
}
