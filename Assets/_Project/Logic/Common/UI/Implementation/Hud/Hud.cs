using _Project.Common.UI.Core;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Common.UI.Implementation.Hud
{
    public class Hud : Window<HudViewModel>
    {
        [SerializeField] private Button _openSpawnWindow;
        [SerializeField] private Button _openStatsWindow;

        private void Start()
        {
            _openSpawnWindow
                .OnClickAsObservable()
                .Subscribe(_ => ViewModel.SwitchToSpawnWindow())
                .AddTo(this);
            
            _openStatsWindow
                .OnClickAsObservable()
                .Subscribe(_ => ViewModel.SwitchToStatsWindow())
                .AddTo(this);
        }

        protected override void Block()
        {
            _openSpawnWindow.enabled = false;
            _openStatsWindow.enabled = false;
        }

        protected override void Unblock()
        {
            _openStatsWindow.enabled = true;
            _openSpawnWindow.enabled = true;
        }

    }
}