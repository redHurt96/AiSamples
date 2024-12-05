using _Project.Common.UI.Core;
using _Project.Common.UI.Implementation.Hud;
using _Project.Common.UI.Implementation.Stats;
using _Project.Common.UI.Spawning;

namespace _Project.Common.UI.Implementation
{
    public class GameWindowSwitcher : WindowsSwitcher
    {
        public GameWindowSwitcher(WindowsFactory windowsFactory) : base(windowsFactory)
        {
        }

        public void ToHud() => Show<Hud.Hud, HudViewModel>();
        public void ToSpawn() => Show<SpawnWindow, SpawnViewModel>();
        public void ToStats() => Show<StatsWindow, StatsViewModel>();
    }
}