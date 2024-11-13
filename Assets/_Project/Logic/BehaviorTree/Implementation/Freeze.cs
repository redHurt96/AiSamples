using _Project.BehaviorTree.Core;
using _Project.Common.Characters.Model;

namespace _Project.BehaviorTree.Implementation
{
    public class Freeze : Node
    {
        private readonly Character _character;

        public Freeze(Character character) => 
            _character = character;

        public override Status Evaluate()
        {
            if (_character.InFreeze)
            {
                _character.StopMovement();
                return Status.Running;
            }
            
            return Status.Failure;
        }
    }
}