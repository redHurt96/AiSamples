using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.Mathf;
using static UnityEngine.Time;

namespace _Project.Logic.Common.Characters
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private float _updatePathCooldown;
        [SerializeField, ReadOnly] private float _currentCooldown;

        private bool InCooldown => _currentCooldown > .1f;

        private void Update() => 
            _currentCooldown = Max(_currentCooldown - deltaTime, 0f);

        public void MoveTo(Vector3 target)
        {
            if (_navMeshAgent.destination == target || InCooldown)
                return;

            _navMeshAgent.SetDestination(target);
            _currentCooldown = _updatePathCooldown;
        }
    }
}