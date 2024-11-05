using System;
using UnityEngine;
using static UnityEngine.Mathf;
using static UnityEngine.Vector3;

namespace _Project.Logic.Common.Characters
{
    public class Character : MonoBehaviour
    {
        public event Action Died;

        public string Id = Guid.NewGuid().ToString();
        public bool HasEnemy => _enemy is { IsAlive : true };
        public bool IsAlive => _health.IsAlive;
        public Vector3 Position => transform.position;
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

        private void Start() => 
            _health.Died += Die;

        private void OnDestroy() => 
            _health.Died -= Die;

        public void AssignEnemy(Character enemy) => 
            _enemy = enemy;

        public void MoveToEnemy() => 
            _movement.MoveTo(_enemy.Position);

        public void AttackEnemy() => 
            _attack.Execute(_enemy);

        public void TakeDamage(float value) => 
            _health.TakeDamage(value);

        private void Die() => 
            Died?.Invoke();
    }
}