using _Project.Common.Ai;
using _Project.Logic.Common.Ai;
using _Project.Logic.Common.Characters;
using _Project.Logic.Common.Services;
using _Project.RuleBasedAi.Core;

namespace _Project.RuleBasedAi.Implementation
{
    public class RuleBasedAiFactory : AiFactory
    {
        public RuleBasedAiFactory(CharactersFactory charactersFactory, ActorsRepository actorsRepository,
            CharactersRepository charactersRepository) : base(charactersFactory, actorsRepository, charactersRepository)
        {
        }

        public override IAiActor CreateAiActor(Character character) =>
            new RuleBasedAiActor(
                new FindEnemy(character, CharactersRepository),
                new MoveToEnemy(character),
                new Attack(character));
    }
}