using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    /// <summary>
    /// An abstract implemmentation of a behavior tree that build the tree and evaluate it continuously
    /// </summary>
    public abstract class Tree : MonoBehaviour
    {
        /// <summary>
        /// a node that recursively contains the entire tree
        /// </summary>
        private Node root = null;

        /// <summary>
        /// Build the behavior tree according to the SetupTree function that will be defined in the derived classes
        /// </summary>
        protected void Start()
        {
            root = SetUpTree();
        }

        /// <summary>
        /// If there is a tree defined, it will evaluate it continuously
        /// </summary>
        private void Update()
        {
            if(root != null)
            {
                root.Evaluate();
            }
        }

        protected abstract Node SetUpTree();
    }
}

