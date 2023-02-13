using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UtilityAI.Core;

namespace UtilityAI.Actions
{
    [CreateAssetMenu(fileName = "FollowTheKing", menuName = "UtilityAI/Actions/FollowTheKing")]
    public class FollowTheKing : Action
    {
        public override void Execute(SoldierController npc)
        {
            npc.FollowTheKing();
            npc.OnFinishedAction();
        }
    }
}
