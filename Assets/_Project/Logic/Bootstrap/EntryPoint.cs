using System.Linq;
using _Project.Logic.Common.Ai;
using _Project.Logic.Common.Services;
using _Project.RuleBasedAi.Implementation;
using _Project.StateMachineAi.Implementation;
using UnityEngine;

namespace _Project.Logic.Bootstrap
{
    public class EntryPoint : MonoBehaviour
    {
        private CharactersRepository _charactersRepository;
        private CharactersFactory _charactersFactory;
        private ActorsRepository _actorsRepository;
        private RuleBasedAiFactory _ruleBasedFactory;
        private StateMachineAiFactory _stateMachineAiFactory;

        private void Start()
        {
            _charactersRepository = new();
            _charactersFactory = new(_charactersRepository);
            _actorsRepository = new();
            _ruleBasedFactory = new(_charactersFactory, _actorsRepository, _charactersRepository);
            _stateMachineAiFactory = new(_charactersFactory, _actorsRepository, _charactersRepository);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                _ruleBasedFactory.Create();
            
            if (Input.GetKeyDown(KeyCode.Alpha2))
                _stateMachineAiFactory.Create();
            
            foreach (IAiActor aiActor in _actorsRepository.All.ToArray())
                aiActor.Update();
        }
    }
}
