using System;

namespace _Project.BehaviorTree.Core
{
    public class Selector : Node
    {
        private readonly Node[] _node;

        public Selector(params Node[] node) => 
            _node = node;

        public override Status Evaluate()
        {
            foreach (Node node in _node)
            {
                switch (node.Evaluate())
                {
                    case Status.Failure:
                        continue;
                    case Status.Running:
                        return Status.Running;
                    case Status.Success:
                        return Status.Success;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            
            return Status.Failure;
        }
    }
}