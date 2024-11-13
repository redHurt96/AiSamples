using _Project.Common.Characters.Model;
using _Project.StateMachineAi.Core;

namespace _Project.StateMachineAi.Implementation
{
    public class Idle : IEnterState, IExitState
    {
        private readonly Character _character;

        public Idle(Character character) => 
            _character = character;

        public void OnEnter() => 
            _character.StopMovement();

        public void OnExit() => 
            _character.EnableMovement();
    }
}