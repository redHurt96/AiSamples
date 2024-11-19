using System.Linq;
using _Project.BehaviorTree.Implementation;
using _Project.Common.Ai;
using _Project.Common.Services;
using _Project.Common.UI.Core;
using _Project.Common.UI.Hud;
using _Project.Goap.Implementation;
using _Project.Logic.UtilityAi.Implementation;
using _Project.RuleBasedAi.Implementation;
using _Project.StateMachineAi.Implementation;
using UnityEngine;

namespace _Project.Logic.Bootstrap
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private Transform _canvas;
        [SerializeField] private Transform _windowsCanvas;
        [SerializeField] private Camera _camera;
        
        private CharactersRepository _charactersRepository;
        private CharactersFactory _charactersFactory;
        private ActorsRepository _actorsRepository;
        private RuleBasedAiFactory _ruleBasedFactory;
        private StateMachineAiFactory _stateMachineAiFactory;
        private HealthViewRepository _healthViewRepository;
        private HealthViewFactory _healthViewFactory;
        private WindowsSwitcher _windowsSwitcher;
        private WindowsRepository _windowsRepository;
        private WindowsFactory _windowsFactory;
        private Spawner _spawner;
        private BehaviorTreeActorFactory _behaviorTreeAiFactory;
        private UtilityAiFactory _utilityAiFactory;
        private FreezeEffectFactory _freezeEffectFactory;
        private GoapAiFactory _goapAiFactory;

        private void Awake()
        {
            _spawner = new();
            _windowsRepository = new();
            _windowsFactory = new(_windowsCanvas, _windowsRepository, _spawner);
            _windowsSwitcher = new(_windowsFactory);
            _charactersRepository = new();
            _healthViewRepository = new();
            _freezeEffectFactory = new();
            _healthViewFactory = new(_healthViewRepository, _canvas, _camera);
            _charactersFactory = new(_charactersRepository, _healthViewFactory, _freezeEffectFactory);
            _actorsRepository = new();
            _ruleBasedFactory = new(_charactersFactory, _actorsRepository, _charactersRepository);
            _stateMachineAiFactory = new(_charactersFactory, _actorsRepository, _charactersRepository);
            _behaviorTreeAiFactory = new(_charactersFactory, _actorsRepository, _charactersRepository);
            _utilityAiFactory = new(_charactersFactory, _actorsRepository, _charactersRepository);
            _goapAiFactory = new(_charactersFactory, _actorsRepository, _charactersRepository);
            
            _windowsFactory.InstallWindowsSwitcher(_windowsSwitcher);
            
            _spawner.Register(AiType.RuleBased, _ruleBasedFactory);
            _spawner.Register(AiType.StateMachine, _stateMachineAiFactory);
            _spawner.Register(AiType.BehaviorTree, _behaviorTreeAiFactory);
            _spawner.Register(AiType.UtilityAi, _utilityAiFactory);
            _spawner.Register(AiType.GOAP, _goapAiFactory);
        }

        private void Start() => 
            _windowsSwitcher.Show<Hud>();

        private void Update()
        {
            _spawner.Update();
            
            foreach (IAiActor aiActor in _actorsRepository.All.ToArray())
                aiActor.Update();
        }
    }
}
