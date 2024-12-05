using _Project.Common.UI.Core;

namespace _Project.Common.UI.Implementation.Hud
{
    public class HudViewModel
    {
        private readonly GameWindowSwitcher _windowsSwitcher;

        public HudViewModel(GameWindowSwitcher windowsSwitcher) => 
            _windowsSwitcher = windowsSwitcher;

        public void SwitchToSpawnWindow() => 
            _windowsSwitcher.ToSpawn();

        public void SwitchToStatsWindow() => 
            _windowsSwitcher.ToStats();
    }
}