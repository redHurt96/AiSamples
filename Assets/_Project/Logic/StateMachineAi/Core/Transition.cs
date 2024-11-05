using System;

namespace _Project.StateMachineAi.Core
{
    public class Transition<TFrom, TTo> : ITransition
        where TFrom : IState
        where TTo : IState
    {
        private readonly Func<bool> _condition;

        public Type To { get; }

        public Transition(Func<bool> condition)
        {
            _condition = condition;
            To = typeof(TTo);
        }

        public bool CanTranslate(IState fromState) => 
            fromState is TFrom && _condition();
    }
}