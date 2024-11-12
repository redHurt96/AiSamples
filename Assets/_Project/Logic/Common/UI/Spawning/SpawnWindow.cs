using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Common.UI.Spawning
{
    public class SpawnWindow : MonoBehaviour, IWindow
    {
        [SerializeField] private AiTypeButton _aiTypeButtonPrefab;
        [SerializeField] private Button _close;
        [SerializeField] private Transform _buttonsParent;
        
        private SpawnViewModel _spawnViewModel;

        public void Construct(SpawnViewModel spawnViewModel) => 
            _spawnViewModel = spawnViewModel;

        private void Start()
        {
            foreach (AiType aiType in _spawnViewModel.AvailableTypes) 
                CreateButton(aiType);

            _close
                .OnClickAsObservable()
                .Subscribe(_ => _spawnViewModel.SwitchToHud())
                .AddTo(this);
        }

        private void CreateButton(AiType aiType)
        {
            AiTypeButton instance = Instantiate(_aiTypeButtonPrefab, _buttonsParent);
            instance.Construct(aiType);
            instance
                .OnClickAsObservable()
                .Subscribe(_ => _spawnViewModel.SwitchAi(aiType))
                .AddTo(this);

            _spawnViewModel.CurrentAiType
                .Subscribe(x =>
                {
                    if (x == aiType)
                        instance.Select();
                    else
                        instance.Deselect();
                })
                .AddTo(this);
        }

        public void Show() => 
            gameObject.SetActive(true);

        public void Hide() => 
            gameObject.SetActive(false);
    }
}
