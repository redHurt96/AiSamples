using _Project.Common.Characters.Model;
using _Project.RuleBasedAi.Core;

namespace _Project.RuleBasedAi.Implementation
{
    public class Attack : IRule
    {
        public bool CanExecute => _character.HasEnemy
                                  && _character.CloseEnoughToAttack
                                  && !_character.InAttackCooldown;

        private readonly Character _character;

        public Attack(Character character) => 
            _character = character;

        public void Execute() => 
            _character.AttackEnemy();
    }
}