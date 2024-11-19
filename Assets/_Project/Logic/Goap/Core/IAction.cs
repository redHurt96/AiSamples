namespace _Project.Goap.Core
{
    public interface IAction<in T> where T : IContext
    {
        bool NeedToBreakPlan(T withContext);
        bool CanExecute(T forContext);
        void MockExecute(T forContext);
        void Execute(T forContext);
    }
}