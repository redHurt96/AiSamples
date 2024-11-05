using _Project.Logic.Common.Characters;
using _Project.StateMachineAi.Core;

namespace _Project.StateMachineAi.Implementation
{
    public class MoveToEnemy : IUpdateState
    {
        private readonly Character _character;

        public MoveToEnemy(Character character) => 
            _character = character;

        public void Update() => 
            _character.MoveToEnemy();
    }
}