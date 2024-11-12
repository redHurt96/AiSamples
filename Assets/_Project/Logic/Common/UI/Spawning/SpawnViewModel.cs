using System.Collections.Generic;
using UniRx;

namespace _Project.Common.UI.Spawning
{
    public class SpawnViewModel
    {
        public IReadOnlyReactiveProperty<AiType> CurrentAiType => _spawner.CurrentCurrentAiType;
        public IEnumerable<AiType> AvailableTypes => _spawner.AvailableTypes;
        
        private readonly Spawner _spawner;
        private readonly WindowsSwitcher _windowsSwitcher;

        public SpawnViewModel(Spawner spawner, WindowsSwitcher windowsSwitcher)
        {
            _spawner = spawner;
            _windowsSwitcher = windowsSwitcher;
        }

        public void SwitchAi(AiType aiType) => 
            _spawner.SetAiType(aiType);

        public void SwitchToHud() => 
            _windowsSwitcher.Show<Hud>();
    }
}