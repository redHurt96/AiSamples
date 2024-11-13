using _Project.BehaviorTree.Core;
using _Project.Common.Characters.Model;
using _Project.Common.Services;

namespace _Project.BehaviorTree.Implementation
{
    public class FindEnemy : Node
    {
        private readonly Character _character;
        private readonly CharactersRepository _repository;

        public FindEnemy(Character character, CharactersRepository repository)
        {
            _character = character;
            _repository = repository;
        }

        public override Status Evaluate()
        {
            Character enemy = _repository.GetClosestEnemy(_character);
            _character.AssignEnemy(enemy);

            return Status.Success;
        }
    }
}