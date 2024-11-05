using System;

namespace _Project.StateMachineAi.Core
{
    public interface ITransition
    {
        Type To { get; }
        bool CanTranslate(IState fromState);
    }
}