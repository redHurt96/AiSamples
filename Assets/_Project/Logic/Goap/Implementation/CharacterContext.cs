using _Project.Common.Characters.Model;
using _Project.Goap.Core;

namespace _Project.Goap.Implementation
{
    public class CharacterContext : IContext
    {
        public bool EnemyKilled;
        public bool HasEnemy;
        public bool CloseToEnemy;
        public bool InCooldown;
        public bool InFreeze;
        
        public readonly Character Character;

        public CharacterContext(Character character) => 
            Character = character;

        public void Update()
        {
            EnemyKilled = Character.IsEnemyDead;
            HasEnemy = Character.HasEnemy;
            CloseToEnemy = Character.HasEnemy && Character.CloseEnoughToAttack;
            InCooldown = Character.InAttackCooldown;
            InFreeze = Character.InFreeze;
        }

        public IContext Copy()
        {
            return new CharacterContext(Character)
            {
                EnemyKilled = EnemyKilled,
                HasEnemy = HasEnemy,
            };
        }
    }
}