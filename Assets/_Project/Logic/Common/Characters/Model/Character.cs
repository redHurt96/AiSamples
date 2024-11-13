using System;
using UniRx;
using UnityEngine;
using static UnityEngine.Mathf;
using static UnityEngine.Vector3;

namespace _Project.Common.Characters.Model
{
    public class Character : MonoBehaviour
    {
        public float DistanceToEnemySqr => SqrMagnitude(Position - _enemy.Position);
        public string Id = Guid.NewGuid().ToString();
        public bool HasEnemy => _enemy != null && _enemy.IsAlive.Value;
        public IReadOnlyReactiveProperty<bool> IsAlive => _health.IsAlive;
        public Vector3 Position => _movement.Position.Value;
        [field:SerializeField] public int Team { get; private set; }
        public bool CloseEnoughToAttack => 
            SqrMagnitude(Position - _enemy.Position) <= Pow(AttackDistance, 2f);
        public bool InAttackCooldown => _attack.InCooldown;
        public float AttackDistance => _attack.Distance;
        public bool InFreeze => _freezeEffect.InFreeze.Value;

        [SerializeField] private Attack _attack;
        [SerializeField] private Movement _movement;
        [SerializeField] private Health _health;
        [SerializeField] private Freeze _freeze;
        [SerializeField] private FreezeEffect _freezeEffect;
        
        private Character _enemy;

        public void Construct(int team) => 
            Team = team;

        public void AssignEnemy(Character enemy) => 
            _enemy = enemy;

        public void MoveToEnemy() => 
            _movement.MoveTo(_enemy.Position);

        public void AttackEnemy()
        {
            _attack.Execute(_enemy);
            _freeze.TryFreeze(_enemy);
        }

        public void TakeDamage(float value) => 
            _health.TakeDamage(value);

        public void Freeze(float freezeTime) => 
            _freezeEffect.Execute(freezeTime);

        public void StopMovement() => 
            _movement.Stop();

        public void EnableMovement() => 
            _movement.Enable();
    }
}