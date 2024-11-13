using _Project.Common.Characters.Model;
using _Project.RuleBasedAi.Core;

namespace _Project.RuleBasedAi.Implementation
{
    public class Freeze : IRule
    {
        public bool CanExecute => _character.InFreeze;
        
        private readonly Character _character;

        public Freeze(Character character) => 
            _character = character;

        public void Execute() => 
            _character.StopMovement();
    }
}