using _Project.Common.Characters.Model;
using _Project.Logic.UtilityAi.Core;
using UnityEngine;

namespace _Project.Logic.UtilityAi.Implementation
{
    public class Attack : IAction
    {
        private readonly Character _character;

        public float Efficiency
        {
            get
            {
                if (!_character.HasEnemy || _character.InAttackCooldown)
                    return 0f;

                return Mathf.Lerp(1f, 0f, (_character.DistanceToEnemySqr - _character.AttackDistance) / _character.AttackDistance);
            }
        }

        public Attack(Character character) => 
            _character = character;

        public void Act() => 
            _character.AttackEnemy();
    }
}