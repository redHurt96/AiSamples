using _Project.Common.Ai;
using _Project.Common.Characters.Model;
using _Project.Common.Services;
using _Project.Goap.Core;

namespace _Project.Goap.Implementation
{
    public class GoapAiFactory : AiFactory
    {
        public GoapAiFactory(CharactersFactory charactersFactory, ActorsRepository actorsRepository, CharactersRepository charactersRepository) : base(charactersFactory, actorsRepository, charactersRepository)
        {
        }

        protected override IAiActor CreateAiActor(Character character) =>
            new GoapAiActor<CharacterContext>(
                new(character)
                {
                    EnemyKilled = character.IsEnemyDead,
                    HasEnemy = character.HasEnemy,
                },
                new IGoal<CharacterContext>[]
                {
                    new WaitUntilUnfreeze(),
                    new KillEnemy(),
                },
                new IAction<CharacterContext>[]
                {
                    new FindEnemyAction(CharactersRepository),
                    new MoveToEnemyAction(),
                    new AttackAction(),
                    new FreezeWaitAction(),
                });
    }
}
