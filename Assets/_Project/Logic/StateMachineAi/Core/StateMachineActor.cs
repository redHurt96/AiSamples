using System.Linq;
using _Project.Common.Ai;
using UnityEngine;

namespace _Project.StateMachineAi.Core
{
    public class StateMachineActor : IAiActor
    {
        private IState _current;
        
        private readonly string _id;
        private readonly IState[] _states;
        private readonly ITransition[] _transitions;

        public StateMachineActor(string id, IState originState, IState[] states, ITransition[] transitions)
        {
            _id = id;
            _current = originState;
            _states = states.Concat(new[] { originState }).ToArray();
            _transitions = transitions;
        }

        public void Update()
        {
            foreach (ITransition transition in _transitions)
            {
                if (transition.CanTranslate(_current))
                    Translate(transition);
            }
            
            if (_current is IUpdateState updateState)
                updateState.Update();
        }

        private void Translate(ITransition transition)
        {
            Debug.Log($"Translate from {_current.GetType().Name} to {transition.To.Name}");
            
            if (_current is IExitState exitState)
                exitState.OnExit();

            _current = _states.First(x => x.GetType() == transition.To);
            
            if (_current is IEnterState enterState)
                enterState.OnEnter();
        }
    }
}