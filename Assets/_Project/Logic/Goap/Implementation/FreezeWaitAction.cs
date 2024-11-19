using _Project.Goap.Core;

namespace _Project.Goap.Implementation
{
    public class FreezeWaitAction : IAction<CharacterContext>
    {
        public bool NeedToBreakPlan(CharacterContext withContext) => 
            false;

        public bool CanExecute(CharacterContext forContext) => 
            forContext.InFreeze;

        public void MockExecute(CharacterContext forContext) => 
            forContext.InFreeze = false;

        public void Execute(CharacterContext forContext) {}
    }
}