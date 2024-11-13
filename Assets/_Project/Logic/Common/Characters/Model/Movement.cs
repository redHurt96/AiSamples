using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.Mathf;
using static UnityEngine.Time;

namespace _Project.Common.Characters.Model
{
    public class Movement : MonoBehaviour
    {
        public IReadOnlyReactiveProperty<Vector3> Position;
        
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private float _updatePathCooldown;
        [SerializeField] private float _speed;
        [SerializeField, ReadOnly] private float _currentCooldown;

        private bool InCooldown => _currentCooldown > .1f;

        private void Awake() =>
            Position = transform
                .ObserveEveryValueChanged(x => x.position)
                .ToReadOnlyReactiveProperty();

        private void Update() => 
            _currentCooldown = Max(_currentCooldown - deltaTime, 0f);

        public void MoveTo(Vector3 target)
        {
            if (_navMeshAgent.destination == target || InCooldown)
                return;

            Enable();
            _navMeshAgent.SetDestination(target);
            _currentCooldown = _updatePathCooldown;
        }

        public void Stop() =>
            _navMeshAgent.speed = 0f;

        public void Enable() => 
            _navMeshAgent.speed = _speed;
    }
}