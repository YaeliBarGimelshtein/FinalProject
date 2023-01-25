using System.Collections;
using System.Collections.Generic;

namespace BehaviorTree
{
    /// <summary>
    /// each node has an execution state that determines whether its currently { running , success, failure}
    /// </summary>
    public enum NodeState
    {
        RUNNING,
        SUCCESS,
        FAILURE
    }

    /// <summary>
    /// Represents a single element in the tree that can access both its children and its parent, has a state and can store, retrieve or clear shared data.
    /// </summary>
    public class Node
    {
        public Node parent;
        protected List<Node> children = new List<Node>();
        protected NodeState state;
        private Dictionary<string, object> dataContext = new Dictionary<string, object>();

        public Node()
        {
            parent = null;
        }

        public Node(List<Node> children)
        {
            foreach (Node child in children)
            {
                _Attach(child);
            }
        }

        private void _Attach(Node node)
        {
            node.parent = this;
            children.Add(node);
        }

        /// <summary>
        /// computing the evaluation of the state of the node.
        /// </summary>
        /// <returns>The state of the node</returns>
        public virtual NodeState Evaluate() => NodeState.FAILURE;

        /// <summary>
        /// Sets data in the shared data system between all branches
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SetData(string key, object value)
        {
            dataContext[key] = value;
        }

        /// <summary>
        /// Gets data in any part of the branch, not only in a particular node
        /// </summary>
        /// <param name="key"></param>
        /// <returns>the data</returns>
        public object GetData(string key)
        {
            object value = null;
            if(dataContext.TryGetValue(key, out value))
            {
                return value;
            }

            Node node = parent;
            while(node != null)
            {
                value = node.GetData(key);
                if(value != null)
                {
                    return value;
                }
                node = node.parent;
            }
            return null;
        }

        public bool ClearData(string key)
        {
            if (dataContext.ContainsKey(key))
            {
                dataContext.Remove(key);
                return true;
            }

            Node node = parent;
            while (node != null)
            {
                bool cleared = node.ClearData(key);
                if (cleared)
                {
                    return true;
                }
                node = node.parent;
            }
            return false;
        }
    }
}

