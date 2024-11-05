using _Project.Logic.Common.Characters;
using _Project.RuleBasedAi.Core;

namespace _Project.RuleBasedAi.Implementation
{
    public class MoveToEnemy : IRule
    {
        private readonly Character _character;

        public bool CanExecute => _character.HasEnemy
                                  && !_character.CloseEnoughToAttack;

        public MoveToEnemy(Character character) => 
            _character = character;

        public void Execute() => 
            _character.MoveToEnemy();
    }
}