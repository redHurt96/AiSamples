using _Project.Goap.Core;

namespace _Project.Goap.Implementation
{
    public class WaitUntilUnfreeze : IGoal<CharacterContext>
    {
        public float Priority(CharacterContext forContext) =>
            forContext.InFreeze
                ? 100
                : 0;

        public bool IsAchieved(CharacterContext fromContext) => 
            !fromContext.InFreeze;
    }
}