using _Project.BehaviorTree.Core;
using _Project.Common.Ai;
using _Project.Common.Characters.Model;
using _Project.Common.Services;

namespace _Project.BehaviorTree.Implementation
{
    public class BehaviorTreeActorFactory : AiFactory
    {
        public BehaviorTreeActorFactory(CharactersFactory charactersFactory, ActorsRepository actorsRepository,
            CharactersRepository charactersRepository) : base(charactersFactory, actorsRepository, charactersRepository)
        {
        }

        protected override IAiActor CreateAiActor(Character character)
        {
            Selector root = new(
                new Freeze(character),
                new CanFindEnemy(
                    new FindEnemy(character, CharactersRepository), character, CharactersRepository),
                new MoveToEnemy(character),
                new Attack(character));

            BehaviourTreeActor actor = new(root);

            return actor;
        }
    }
}