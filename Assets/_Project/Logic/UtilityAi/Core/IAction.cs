namespace _Project.Logic.UtilityAi.Core
{
    public interface IAction
    {
        float Efficiency { get; }
        
        void Act();
    }
}
