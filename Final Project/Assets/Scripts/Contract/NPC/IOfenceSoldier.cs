using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Contract.NPC
{
    interface IOfenceSoldierBehaviour
    {
        void Defend();
        void Attack();
        void Fallback();
    }
}
