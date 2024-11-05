using _Project.Logic.Common.Characters;
using _Project.StateMachineAi.Core;

namespace _Project.StateMachineAi.Implementation
{
    public class Attack : IEnterState
    {
        private readonly Character _character;

        public Attack(Character character) => 
            _character = character;

        public void OnEnter() => 
            _character.AttackEnemy();
    }
}