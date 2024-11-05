using _Project.Logic.Common.Characters;
using _Project.Logic.Common.Services;
using _Project.StateMachineAi.Core;

namespace _Project.StateMachineAi.Implementation
{
    public class FindEnemy : IEnterState
    {
        private readonly Character _character;
        private readonly CharactersRepository _charactersRepository;

        public FindEnemy(Character character, CharactersRepository charactersRepository)
        {
            _character = character;
            _charactersRepository = charactersRepository;
        }

        public void OnEnter()
        {
            Character enemy = _charactersRepository.GetClosestEnemy(_character);
            _character.AssignEnemy(enemy);
        }
    }
}
