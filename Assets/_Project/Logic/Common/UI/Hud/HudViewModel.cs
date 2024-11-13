using _Project.Common.UI.Core;
using _Project.Common.UI.Spawning;

namespace _Project.Common.UI.Hud
{
    public class HudViewModel
    {
        private readonly WindowsSwitcher _windowsSwitcher;

        public HudViewModel(WindowsSwitcher windowsSwitcher) => 
            _windowsSwitcher = windowsSwitcher;

        public void SwitchToSpawnWindow() => 
            _windowsSwitcher.Show<SpawnWindow>();
    }
}