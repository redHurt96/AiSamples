using System;
using System.Collections.Generic;
using UniRx;
using Zenject;

namespace _Project.Common.Services
{
    public class Stats : IInitializable, IDisposable
    {
        public event Action OnStatsChanged;
        public IDictionary<int, int> Teams => _teams;
        
        private readonly KillCounter _killCounter;
        private readonly Dictionary<int, int> _teams = new();
        private readonly CompositeDisposable _disposable = new();

        public Stats(KillCounter killCounter) => 
            _killCounter = killCounter;

        public void Initialize() =>
            _killCounter.OnKill
                .Subscribe(Count)
                .AddTo(_disposable);

        public void Dispose() => 
            _disposable.Dispose();

        private void Count(KillEventData killEventData)
        {
            if (!_teams.TryAdd(killEventData.KillerTeam, 1))
                _teams[killEventData.KillerTeam] += 1;

            OnStatsChanged?.Invoke();
        }
    }
}