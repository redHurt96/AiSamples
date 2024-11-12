using System.Collections.Generic;
using _Project.Common.Ai;
using UniRx;

namespace _Project.Common.UI.Spawning
{
    public class Spawner
    {
        public IReadOnlyReactiveProperty<AiType> CurrentCurrentAiType => _currentAiType;
        public IEnumerable<AiType> AvailableTypes => _factories.Keys;

        private readonly ReactiveProperty<AiType> _currentAiType = new(AiType.RuleBased);
        private readonly Dictionary<AiType, AiFactory> _factories = new();
        
        public void SetAiType(AiType aiType) => 
            _currentAiType.Value = aiType;

        public void Register(AiType aiType, AiFactory aiFactory) => 
            _factories[aiType] = aiFactory;

        public void Spawn() => 
            _factories[CurrentCurrentAiType.Value].Create();
    }
}