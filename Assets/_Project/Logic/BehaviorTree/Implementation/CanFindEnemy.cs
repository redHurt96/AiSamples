using _Project.BehaviorTree.Core;
using _Project.Common.Characters.Model;
using _Project.Common.Services;

namespace _Project.BehaviorTree.Implementation
{
    public class CanFindEnemy : Condition
    {
        private readonly Character _character;
        private readonly CharactersRepository _charactersRepository;

        public CanFindEnemy(Node child, Character character, CharactersRepository charactersRepository) : base(child)
        {
            _character = character;
            _charactersRepository = charactersRepository;
        }

        protected override bool CanEvaluate() =>
            !_character.HasEnemy
            && _charactersRepository.HasEnemy(_character);
    }
}