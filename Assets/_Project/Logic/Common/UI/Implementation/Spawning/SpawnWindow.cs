using System.Collections.Generic;
using _Project.Common.Ai;
using _Project.Common.UI.Core;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Common.UI.Spawning
{
    public class SpawnWindow : Window<SpawnViewModel>
    {
        [SerializeField] private AiTypeButton _aiTypeButtonPrefab;
        [SerializeField] private Button _close;
        [SerializeField] private Transform _buttonsParent;
        
        private readonly List<AiTypeButton> _buttons = new();
        
        private void Start()
        {
            foreach (AiType aiType in ViewModel.AvailableTypes) 
                CreateButton(aiType);

            _close
                .OnClickAsObservable()
                .Subscribe(_ => ViewModel.SwitchToHud())
                .AddTo(this);
        }

        protected override void Block()
        {
            _close.enabled = false;
            foreach (AiTypeButton button in _buttons) 
                button.Disable();
        }

        protected override void Unblock()
        {
            _close.enabled = true;
            foreach (AiTypeButton button in _buttons) 
                button.Enable();
        }

        private void CreateButton(AiType aiType)
        {
            AiTypeButton instance = Instantiate(_aiTypeButtonPrefab, _buttonsParent);
            instance.Construct(aiType);
            instance
                .OnClickAsObservable()
                .Subscribe(_ => ViewModel.SwitchAi(aiType))
                .AddTo(this);
            
            _buttons.Add(instance);

            ViewModel.CurrentAiType
                .Subscribe(x =>
                {
                    if (x == aiType)
                        instance.Select();
                    else
                        instance.Deselect();
                })
                .AddTo(this);
        }
    }
}
