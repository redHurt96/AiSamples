using System;
using _Project.Common.Characters.Model;
using UniRx;
using UnityEngine;
using static UnityEngine.Mathf;
using static UnityEngine.Vector3;

namespace _Project.Logic.Common.Characters
{
    public class Character : MonoBehaviour
    {
        public string Id = Guid.NewGuid().ToString();
        public bool HasEnemy => _enemy != null && _enemy.IsAlive.Value;
        public IReadOnlyReactiveProperty<bool> IsAlive => _health.IsAlive;
        public Vector3 Position => _movement.Position.Value;
        [field:SerializeField] public int Team { get; private set; }
        public bool CloseEnoughToAttack => 
            SqrMagnitude(Position - _enemy.Position) <= Pow(_attack.Distance, 2f);
        public bool InAttackCooldown => _attack.InCooldown;

        [SerializeField] private Attack _attack;
        [SerializeField] private Movement _movement;
        [SerializeField] private Health _health;
        
        private Character _enemy;

        public void Construct(int team) => 
            Team = team;

        public void AssignEnemy(Character enemy) => 
            _enemy = enemy;

        public void MoveToEnemy() => 
            _movement.MoveTo(_enemy.Position);

        public void AttackEnemy() => 
            _attack.Execute(_enemy);

        public void TakeDamage(float value) => 
            _health.TakeDamage(value);
    }
}