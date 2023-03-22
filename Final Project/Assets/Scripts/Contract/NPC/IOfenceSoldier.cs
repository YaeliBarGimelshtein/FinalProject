using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Contract.NPC
{
    interface IOfenceSoldierBehaviour
    {
        void Attack();
        void Fallback();
        void FollowTheKing();
        void ProtectTheKing();
    }
}
