using _Project.Common.Characters.Model;
using _Project.Common.Services;
using _Project.Logic.UtilityAi.Core;

namespace _Project.Logic.UtilityAi.Implementation
{
    public class FindEnemy : IAction
    {
        private readonly Character _character;
        private readonly CharactersRepository _charactersRepository;

        public float Efficiency => !_character.HasEnemy && _charactersRepository.HasEnemy(_character)
            ? 1f
            : 0f;

        public FindEnemy(Character character, CharactersRepository charactersRepository)
        {
            _character = character;
            _charactersRepository = charactersRepository;
        }

        public void Act()
        {
            Character enemy = _charactersRepository.GetClosestEnemy(_character);
            _character.AssignEnemy(enemy);
        }
    }
}