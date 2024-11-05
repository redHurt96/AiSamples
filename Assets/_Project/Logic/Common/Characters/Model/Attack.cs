using Sirenix.OdinInspector;
using UnityEngine;
using static UnityEngine.Mathf;
using static UnityEngine.Time;

namespace _Project.Logic.Common.Characters
{
    public class Attack : MonoBehaviour
    {
        public bool InCooldown => _currentCooldown > .05f;
        [field:SerializeField] public float Distance { get; private set; }
        
        [SerializeField] private float _damage;
        [SerializeField] private float _cooldown;
        [SerializeField, ReadOnly] private float _currentCooldown;

        private void Update() => 
            _currentCooldown = Max(_currentCooldown - deltaTime, 0f);

        public void Execute(Character enemy)
        {
            if (InCooldown)
                throw new("Attempt to attack in cooldown!");
            
            enemy.TakeDamage(_damage);
            _currentCooldown = _cooldown;
        }
    }
}