using _Project.Common.Characters.Model;
using _Project.Logic.UtilityAi.Core;
using static UnityEngine.Mathf;

namespace _Project.Logic.UtilityAi.Implementation
{
    public class MoveToEnemy : IAction
    {
        private const float MAX_EFFICIENCY_DISTANCE_SQR = 25f;
        
        private readonly Character _character;

        public float Efficiency =>
            _character.HasEnemy 
                ? Lerp(0, 1, _character.DistanceToEnemySqr / MAX_EFFICIENCY_DISTANCE_SQR) 
                : 0f;

        public MoveToEnemy(Character character) => 
            _character = character;

        public void Act() => 
            _character.MoveToEnemy();
    }
}