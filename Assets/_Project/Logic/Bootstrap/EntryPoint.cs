using System.Linq;
using _Project.BehaviorTree.Implementation;
using _Project.Common.Ai;
using _Project.Common.Services;
using _Project.Common.UI.Core;
using _Project.Common.UI.Implementation;
using _Project.Goap.Implementation;
using _Project.Logic.UtilityAi.Implementation;
using _Project.RuleBasedAi.Implementation;
using _Project.StateMachineAi.Implementation;
using Zenject;

namespace _Project.Logic.Bootstrap
{
    public class EntryPoint : IInitializable, ITickable
    {
        private readonly GameWindowSwitcher _windowsSwitcher;
        private readonly Spawner _spawner;
        private readonly RuleBasedAiFactory _ruleBasedAiFactory;
        private readonly StateMachineAiFactory _stateMachineAiFactory;
        private readonly BehaviorTreeAiFactory _behaviorTreeAiFactory;
        private readonly UtilityAiFactory _utilityAiFactory;
        private readonly GoapAiFactory _goapAiFactory;
        private readonly ActorsRepository _actorsRepository;

        public EntryPoint(GameWindowSwitcher windowsSwitcher, 
            Spawner spawner,
            RuleBasedAiFactory ruleBasedAiFactory, 
            StateMachineAiFactory stateMachineAiFactory, 
            BehaviorTreeAiFactory behaviorTreeAiFactory, 
            UtilityAiFactory utilityAiFactory, 
            GoapAiFactory goapAiFactory,
            ActorsRepository actorsRepository)
        {
            _windowsSwitcher = windowsSwitcher;
            _spawner = spawner;
            _ruleBasedAiFactory = ruleBasedAiFactory;
            _stateMachineAiFactory = stateMachineAiFactory;
            _behaviorTreeAiFactory = behaviorTreeAiFactory;
            _utilityAiFactory = utilityAiFactory;
            _goapAiFactory = goapAiFactory;
            _actorsRepository = actorsRepository;
        }

        public void Initialize()
        {
            _spawner.Register(AiType.RuleBased, _ruleBasedAiFactory);
            _spawner.Register(AiType.StateMachine, _stateMachineAiFactory);
            _spawner.Register(AiType.BehaviorTree, _behaviorTreeAiFactory);
            _spawner.Register(AiType.UtilityAi, _utilityAiFactory);
            _spawner.Register(AiType.GOAP, _goapAiFactory);
            
            _windowsSwitcher.ToHud();
        }

        public void Tick()
        {
            _spawner.Update();
            
            foreach (IAiActor aiActor in _actorsRepository.All.ToArray())
                aiActor.Update();
        }
    }
}