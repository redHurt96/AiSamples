namespace _Project.BehaviorTree.Core
{
    public abstract partial class Node
    {
        public enum Status
        {
            Failure = 0,
            Running,
            Success,
        }
    }
}