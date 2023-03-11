using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UtilityAI.Core;

namespace UtilityAI.Considerations
{
    [CreateAssetMenu(fileName = "IsEnemyAttackingConsideration", menuName = "UtilityAI/Considerations/IsEnemyAttackingConsideration")]
    public class IsEnemyAttackingConsideration : Consideration
    {
        public override float ScoreConsideration(SoldierController npc)
        {
            bool enemyAttack = npc.EnemyAttacking();
            bool isFallingBack = npc.IsFallingBack();
            if(enemyAttack && !isFallingBack)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}

