using System;
using System.Collections.Generic;
using Zenject;

namespace _Project.Common.UI.Implementation.Stats
{
    public class StatsViewModel : IInitializable, IDisposable
    {
        public event Action OnStatsChanged;
        public IDictionary<int, int> TeamStats => _stats.Teams;
        
        private readonly GameWindowSwitcher _windowSwitcher;
        private readonly Services.Stats _stats;

        public StatsViewModel(GameWindowSwitcher windowSwitcher, Services.Stats stats)
        {
            _stats = stats;
            _windowSwitcher = windowSwitcher;
        }

        public void SwitchToHud() => 
            _windowSwitcher.ToHud();

        public void Initialize() => 
            _stats.OnStatsChanged += InvokeEvent;

        public void Dispose() => 
            _stats.OnStatsChanged -= InvokeEvent;

        private void InvokeEvent() =>
            OnStatsChanged?.Invoke();
    }
}