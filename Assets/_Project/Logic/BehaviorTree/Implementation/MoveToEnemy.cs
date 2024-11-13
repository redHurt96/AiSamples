using _Project.BehaviorTree.Core;
using _Project.Common.Characters.Model;

namespace _Project.BehaviorTree.Implementation
{
    public class Attack : Node
    {
        private readonly Character _character;

        public Attack(Character character) => 
            _character = character;

        public override Status Evaluate()
        {
            if (_character.HasEnemy
                && _character.CloseEnoughToAttack
                && !_character.InAttackCooldown)
            {
                _character.AttackEnemy();
                return Status.Success;
            }

            return Status.Failure;
        }
    }
    public class MoveToEnemy : Node
    {
        private readonly Character _character;

        public MoveToEnemy(Character character) => 
            _character = character;

        public override Status Evaluate()
        {
            if (_character.HasEnemy
                && !_character.CloseEnoughToAttack)
            {
                _character.MoveToEnemy();
                return Status.Running;
            }

            return Status.Failure;
        }
    }
}