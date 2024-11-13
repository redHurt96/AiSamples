using _Project.Common.Characters.Model;
using _Project.Logic.UtilityAi.Core;

namespace _Project.Logic.UtilityAi.Implementation
{
    public class Idle : IAction
    {
        public float Efficiency => .1f;
        
        private readonly Character _character;

        public Idle(Character character) => 
            _character = character;

        public void Act() => 
            _character.StopMovement();
    }
}