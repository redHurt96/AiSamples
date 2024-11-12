using UniRx;
using UnityEngine;

namespace _Project.Common.Characters.Model
{
    public class Health : MonoBehaviour
    {
        public IReadOnlyReactiveProperty<bool> IsAlive;

        [field:SerializeField] internal float Max { get; private set; }
        
        internal IReadOnlyReactiveProperty<float> Current => _current;
        
        private ReactiveProperty<float> _current;

        private void Awake()
        {
            _current = new(Max);
            IsAlive = Current.Select(x => x > 0).ToReadOnlyReactiveProperty();
        }

        public void TakeDamage(float value) => 
            _current.Value = Mathf.Max(_current.Value - value, 0f);
    }
}