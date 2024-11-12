using _Project.Common.Ai;
using _Project.Common.Services;
using _Project.Logic.Common.Ai;
using _Project.Logic.Common.Characters;
using _Project.Logic.Common.Services;
using _Project.StateMachineAi.Core;

namespace _Project.StateMachineAi.Implementation
{
    public class StateMachineAiFactory : AiFactory
    {
        public StateMachineAiFactory(CharactersFactory charactersFactory, ActorsRepository actorsRepository, CharactersRepository charactersRepository) : base(charactersFactory, actorsRepository, charactersRepository)
        {
        }

        protected override IAiActor CreateAiActor(Character character) =>
            new StateMachineActor(character.Id,
                new Idle(), 
                new IState[]
                {
                    new FindEnemy(character, CharactersRepository),
                    new MoveToEnemy(character),
                    new Attack(character),
                },
                new ITransition[]
                {
                    new Transition<Idle, FindEnemy>(() => !character.HasEnemy && CharactersRepository.HasEnemy(character)),
                    new Transition<Idle, Attack>(() => character.HasEnemy && character.CloseEnoughToAttack && !character.InAttackCooldown),
                    new Transition<Idle, MoveToEnemy>(() => character.HasEnemy && !character.CloseEnoughToAttack && !character.InAttackCooldown),
                    new Transition<FindEnemy, MoveToEnemy>(() => character.HasEnemy && !character.CloseEnoughToAttack),
                    new Transition<MoveToEnemy, Idle>(() => !character.HasEnemy),
                    new Transition<MoveToEnemy, FindEnemy>(() => !character.HasEnemy && CharactersRepository.HasEnemy(character)),
                    new Transition<MoveToEnemy, Attack>(() => character.HasEnemy && character.CloseEnoughToAttack && !character.InAttackCooldown),
                    new Transition<Attack, FindEnemy>(() => !character.HasEnemy && CharactersRepository.HasEnemy(character)),
                    new Transition<Attack, Idle>(() => character.HasEnemy && character.CloseEnoughToAttack && character.InAttackCooldown),
                });
    }
}