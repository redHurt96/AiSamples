using _Project.Common.Ai;

namespace _Project.BehaviorTree.Core
{
    public class BehaviourTreeActor : IAiActor
    {
        private readonly Node _root;

        public BehaviourTreeActor(Node root) => 
            _root = root;

        public void Update() => 
            _root.Evaluate();
    }
}