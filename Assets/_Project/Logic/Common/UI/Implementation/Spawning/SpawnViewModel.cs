using System.Collections.Generic;
using _Project.Common.Ai;
using _Project.Common.UI.Core;
using _Project.Common.UI.Implementation;
using UniRx;

namespace _Project.Common.UI.Spawning
{
    public class SpawnViewModel
    {
        public IReadOnlyReactiveProperty<AiType> CurrentAiType => _spawner.CurrentCurrentAiType;
        public IEnumerable<AiType> AvailableTypes => _spawner.AvailableTypes;
        
        private readonly Spawner _spawner;
        private readonly GameWindowSwitcher _windowsSwitcher;

        public SpawnViewModel(Spawner spawner, GameWindowSwitcher windowsSwitcher)
        {
            _spawner = spawner;
            _windowsSwitcher = windowsSwitcher;
        }

        public void SwitchAi(AiType aiType) => 
            _spawner.SetAiType(aiType);

        public void SwitchToHud() => 
            _windowsSwitcher.ToHud();
    }
}