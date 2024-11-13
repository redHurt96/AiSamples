using System;

namespace _Project.BehaviorTree.Core
{
    public class Sequence : Node
    {
        private readonly Node[] _node;

        public Sequence(params Node[] node) => 
            _node = node;

        public override Status Evaluate()
        {
            foreach (Node node in _node)
            {
                switch (node.Evaluate())
                {
                    case Status.Failure:
                        return Status.Failure;
                    case Status.Running:
                        return Status.Running;
                    case Status.Success:
                        continue;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            
            return Status.Success;
        }
    }
}