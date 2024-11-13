namespace _Project.BehaviorTree.Core
{
    public abstract class Condition : Node
    {
        private readonly Node _child;

        protected Condition(Node child) => 
            _child = child;

        public override Status Evaluate() =>
            CanEvaluate() 
                ? _child.Evaluate() 
                : Status.Failure;

        protected abstract bool CanEvaluate();
    }
}