using _Project.Logic.Common.Characters;
using _Project.Logic.Common.Services;
using _Project.RuleBasedAi.Core;

namespace _Project.RuleBasedAi.Implementation
{
    public class FindEnemy : IRule
    {
        private readonly Character _character;
        private readonly CharactersRepository _charactersRepository;

        public bool CanExecute => !_character.HasEnemy
                                  && _charactersRepository.HasEnemy(_character);

        public FindEnemy(Character character, CharactersRepository charactersRepository)
        {
            _character = character;
            _charactersRepository = charactersRepository;
        }

        public void Execute()
        {
            Character enemy = _charactersRepository.GetClosestEnemy(_character);
            _character.AssignEnemy(enemy);
        }
    }
}