using System;
using System.Collections.Generic;
using _Project.Common.UI.Core;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Common.UI.Implementation.Stats
{
    public class StatsWindow : Window<StatsViewModel>
    {
        [SerializeField] private Button _close;
        [SerializeField] private TextMeshProUGUI _prefab;
        [SerializeField] private Transform _parent;
        
        private CompositeDisposable _disposable;
        
        private readonly Dictionary<int, TextMeshProUGUI> _stats = new();

        private void Start() =>
            _close
                .OnClickAsObservable()
                .Subscribe(_ => ViewModel.SwitchToHud())
                .AddTo(this);

        protected override void Block()
        {
            _close.enabled = false;
            _disposable?.Dispose();
            ViewModel.OnStatsChanged -= Draw;
        }

        protected override void Unblock()
        {
            _close.enabled = true;

            ViewModel.OnStatsChanged += Draw;
        }

        private void Draw()
        {
            foreach (KeyValuePair<int,int> pair in ViewModel.TeamStats)
                Draw(pair.Key, pair.Value);
        }

        private void Draw(int team, int count)
        {
            if (!_stats.TryGetValue(team, out TextMeshProUGUI text))
            {
                text = Instantiate(_prefab, _parent);
                _stats.Add(team, text);
            }

            text.text = $"Team {team} has destroyed {count} enemies";
        }
    }
}
