using _Project.Common.Ai;
using _Project.Common.Characters.Model;
using _Project.Common.Services;
using _Project.Logic.UtilityAi.Core;

namespace _Project.Logic.UtilityAi.Implementation
{
    public class UtilityAiFactory : AiFactory
    {
        public UtilityAiFactory(CharactersFactory charactersFactory, ActorsRepository actorsRepository, CharactersRepository charactersRepository) : base(charactersFactory, actorsRepository, charactersRepository)
        {
        }

        protected override IAiActor CreateAiActor(Character character) =>
            new UtilityAiActor(
                new Freeze(character),
                new FindEnemy(character, CharactersRepository),
                new MoveToEnemy(character),
                new Attack(character),
                new Idle(character));
    }
}