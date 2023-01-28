using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AStart
{
    public abstract class Node 
    {
        public int gCost;
        public int hCost;
        public int fCost
        {
            get
            {
                return gCost + hCost;
            }
        }
        protected Node parent;
        
        public virtual int ComputeH() => 0;
        public virtual bool TargetNodeFound() => false;
    }
}

