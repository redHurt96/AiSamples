namespace _Project.RuleBasedAi.Core
{
    public interface IRule
    {
        bool CanExecute { get; }

        void Execute();
    }
}
