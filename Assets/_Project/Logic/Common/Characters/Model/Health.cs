using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Project.Logic.Common.Characters
{
    internal class Health : MonoBehaviour
    {
        public event Action Died;
        
        public bool IsAlive => _current > 0f;
        
        [SerializeField] private float _max;
        [SerializeField, ReadOnly] private float _current;

        private void Start() => 
            _current = _max;

        public void TakeDamage(float value)
        {
            _current = Mathf.Max(_current - value, 0f);
        
            if (!IsAlive)
                Died?.Invoke();
        }
    }
}