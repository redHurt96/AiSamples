namespace _Project.Goap.Core
{
    public interface IGoal<in T> where T : IContext
    {
        float Priority(T forContext);
        bool IsAchieved(T fromContext);
    }
}
