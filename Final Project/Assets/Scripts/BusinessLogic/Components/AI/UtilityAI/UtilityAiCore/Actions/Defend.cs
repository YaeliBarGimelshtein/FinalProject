using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UtilityAI.Core;

namespace UtilityAI.Actions
{
    [CreateAssetMenu(fileName = "Defend", menuName = "UtilityAI/Actions/Defend")]
    public class Defend : Action
    {
        public override void Execute(SoldierController npc)
        {
            Debug.Log("do defend");
            npc.Defend();
            //logic
            npc.OnFinishedAction();
        }
    }
}
