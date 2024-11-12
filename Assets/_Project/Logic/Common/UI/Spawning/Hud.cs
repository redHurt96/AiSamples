using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Common.UI.Spawning
{
    public class Hud : MonoBehaviour, IWindow
    {
        [SerializeField] private Button _openSpawnWindow;
        
        private HudViewModel _viewModel;

        public void Construct(HudViewModel viewModel) => 
            _viewModel = viewModel;

        private void Start() =>
            _openSpawnWindow
                .OnClickAsObservable()
                .Subscribe(x => _viewModel.SwitchToSpawnWindow())
                .AddTo(this);

        public void Show() => 
            gameObject.SetActive(true);

        public void Hide() => 
            gameObject.SetActive(false);
    }
}