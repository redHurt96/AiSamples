namespace _Project.StateMachineAi.Core
{
    public interface IState
    {
    }

    public interface IUpdateState : IState
    {
        void Update();
    }

    public interface IEnterState : IState
    {
        void OnEnter();
    }

    public interface IExitState : IState
    {
        void OnExit();
    }
}
