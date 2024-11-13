using System.Collections.Generic;
using _Project.Common.UI.Spawning;
using UniRx;
using UnityEngine;

namespace _Project.Common.Ai
{
    public class Spawner
    {
        public IReadOnlyReactiveProperty<AiType> CurrentCurrentAiType => _currentAiType;
        public IEnumerable<AiType> AvailableTypes => _factories.Keys;

        private readonly ReactiveProperty<AiType> _currentAiType = new(AiType.RuleBased);
        private readonly Dictionary<AiType, AiFactory> _factories = new();
        private readonly Dictionary<KeyCode, int> _teamKey = new()
        {
            [KeyCode.Alpha1] = 0,
            [KeyCode.Alpha2] = 1,
            [KeyCode.Alpha3] = 2,
            [KeyCode.Alpha4] = 3,
        };
        
        public void SetAiType(AiType aiType) => 
            _currentAiType.Value = aiType;

        public void Register(AiType aiType, AiFactory aiFactory) => 
            _factories[aiType] = aiFactory;

        public void Update()
        {
            foreach (KeyValuePair<KeyCode,int> pair in _teamKey)
            {
                if (Input.GetKeyDown(pair.Key))
                    _factories[CurrentCurrentAiType.Value].Create(pair.Value);
            }
        }
    }
}