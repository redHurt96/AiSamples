using _Project.Goap.Core;

namespace _Project.Goap.Implementation
{
    public class KillEnemy : IGoal<CharacterContext>
    {
        public float Priority(CharacterContext forContext) => 
            1f;

        public bool IsAchieved(CharacterContext fromContext) => 
            fromContext.EnemyKilled;
    }
}