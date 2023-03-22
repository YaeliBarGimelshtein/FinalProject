using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UtilityAI.Core
{
    public abstract class Consideration : ScriptableObject
    {
        public string Name;
        private float _score;
        public float score
        {
            get { return _score; }
            set
            {
                _score = Mathf.Clamp01(value);
            }
        }

        public virtual void Awake()
        {
            score = 0;
        }

        public abstract float ScoreConsideration(OffenceSoldierController npc);
    }
}
