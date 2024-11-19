using _Project.Goap.Core;

namespace _Project.Goap.Implementation
{
    public class MoveToEnemyAction : IAction<CharacterContext>
    {
        public bool NeedToBreakPlan(CharacterContext withContext) => 
            withContext.InFreeze;

        public bool CanExecute(CharacterContext forContext) => 
            forContext.HasEnemy && !forContext.CloseToEnemy;

        public void MockExecute(CharacterContext forContext) => 
            forContext.CloseToEnemy = true;

        public void Execute(CharacterContext forContext) => 
            forContext.Character.MoveToEnemy();
    }
}