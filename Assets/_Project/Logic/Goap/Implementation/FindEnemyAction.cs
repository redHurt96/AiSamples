using _Project.Common.Characters.Model;
using _Project.Common.Services;
using _Project.Goap.Core;

namespace _Project.Goap.Implementation
{
    public class FindEnemyAction : IAction<CharacterContext>
    {
        private readonly CharactersRepository _charactersRepository;

        public FindEnemyAction(CharactersRepository charactersRepository) => 
            _charactersRepository = charactersRepository;

        public bool NeedToBreakPlan(CharacterContext withContext) => 
            false;

        public bool CanExecute(CharacterContext forContext) => 
            !forContext.HasEnemy;

        public void MockExecute(CharacterContext forContext) => 
            forContext.HasEnemy = true;

        public void Execute(CharacterContext forContext)
        {
            if (!forContext.HasEnemy && _charactersRepository.HasEnemy(forContext.Character))
            {
                Character target = _charactersRepository.GetClosestEnemy(forContext.Character);
                forContext.Character.AssignEnemy(target);
            }
        }
    }
}