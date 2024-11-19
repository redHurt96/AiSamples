namespace _Project.Goap.Core
{
    public interface IContext
    {
        void Update();
        IContext Copy();
    }
}