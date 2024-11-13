using _Project.Common.Characters.Model;
using _Project.Logic.UtilityAi.Core;

namespace _Project.Logic.UtilityAi.Implementation
{
    public class Freeze : IAction
    {
        private readonly Character _character;

        public float Efficiency => _character.InFreeze
            ? 1f
            : 0f;

        public Freeze(Character character) => 
            _character = character;

        public void Act() => 
            _character.StopMovement();
    }
}