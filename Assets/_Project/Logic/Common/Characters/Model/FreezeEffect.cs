using UniRx;
using UnityEngine;
using static UnityEngine.Mathf;
using static UnityEngine.Time;

namespace _Project.Common.Characters.Model
{
    public class FreezeEffect : MonoBehaviour
    {
        public ReadOnlyReactiveProperty<bool> InFreeze { get; private set; }
        
        private readonly ReactiveProperty<float> _currentFreezeTime = new(0f);

        private void Awake() =>
            InFreeze = _currentFreezeTime
                .Select(x => x > 0)
                .ToReadOnlyReactiveProperty();

        public void Execute(float time) => 
            _currentFreezeTime.Value = time;

        private void Update() => 
            _currentFreezeTime.Value = Max(_currentFreezeTime.Value - deltaTime, 0f);
    }
}