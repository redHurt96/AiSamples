using _Project.BehaviorTree.Implementation;
using _Project.Common.Ai;
using _Project.Common.Services;
using _Project.Common.UI.Core;
using _Project.Common.UI.Implementation;
using _Project.Goap.Implementation;
using _Project.Logic.UtilityAi.Implementation;
using _Project.RuleBasedAi.Implementation;
using _Project.StateMachineAi.Implementation;
using UnityEngine;
using Zenject;

namespace _Project.Logic.Bootstrap
{
    public class GameInstaller : MonoInstaller
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
        private BehaviorTreeAiFactory _behaviorTreeAiFactory;
        private UtilityAiFactory _utilityAiFactory;
        private FreezeEffectFactory _freezeEffectFactory;
        private GoapAiFactory _goapAiFactory;

        public override void InstallBindings()
        {
            Container.Bind<CharactersRepository>().AsSingle();
            Container.Bind<CharactersFactory>().AsSingle();
            Container.Bind<ActorsRepository>().AsSingle();
            Container.Bind<HealthViewRepository>().AsSingle();
            Container.Bind<HealthViewFactory>().AsSingle().WithArguments(_canvas, _camera);
            Container.Bind<GameWindowSwitcher>().AsSingle();
            Container.Bind<WindowsRepository>().AsSingle();
            Container.Bind<WindowsFactory>().AsSingle().WithArguments(_windowsCanvas);
            Container.Bind<Spawner>().AsSingle();
            Container.Bind<FreezeEffectFactory>().AsSingle();
            
            Container.Bind<RuleBasedAiFactory>().AsSingle();
            Container.Bind<StateMachineAiFactory>().AsSingle();
            Container.Bind<BehaviorTreeAiFactory>().AsSingle();
            Container.Bind<UtilityAiFactory>().AsSingle();
            Container.Bind<GoapAiFactory>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<KillCounter>().AsSingle();
            Container.BindInterfacesAndSelfTo<Stats>().AsSingle();
            
            Container.BindInterfacesTo<EntryPoint>().AsSingle();
        }
    }
}
