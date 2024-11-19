using _Project.Goap.Core;

namespace _Project.Goap.Implementation
{
    public class AttackAction : IAction<CharacterContext>
    {
        public bool NeedToBreakPlan(CharacterContext withContext) => 
            withContext.InFreeze;

        public bool CanExecute(CharacterContext forContext) => 
            forContext.CloseToEnemy && !forContext.InCooldown;

        public void MockExecute(CharacterContext forContext)
        {
            forContext.InCooldown = true;
            forContext.EnemyKilled = true;
        }

        public void Execute(CharacterContext forContext) => 
            forContext.Character.AttackEnemy();
    }
}