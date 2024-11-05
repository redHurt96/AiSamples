using _Project.Logic.Common.Ai;
using _Project.Logic.Common.Characters;
using _Project.Logic.Common.Services;

namespace _Project.Common.Ai
{
    public abstract class AiFactory
    {
        protected readonly CharactersFactory CharactersFactory;
        protected readonly ActorsRepository ActorsRepository;
        protected readonly CharactersRepository CharactersRepository;

        public AiFactory(
            CharactersFactory charactersFactory, 
            ActorsRepository actorsRepository,
            CharactersRepository charactersRepository)
        {
            CharactersFactory = charactersFactory;
            ActorsRepository = actorsRepository;
            CharactersRepository = charactersRepository;
        }
        
        public void Create()
        {
            Character character = CharactersFactory.Create();
            IAiActor aiActor = CreateAiActor(character);
            
            character.Died += DisposeAi;
            
            ActorsRepository.Register(aiActor);
            
            void DisposeAi()
            {
                character.Died -= DisposeAi;
                ActorsRepository.Unregister(aiActor);
            }
        }

        public abstract IAiActor CreateAiActor(Character character);
    }
}