using System;
using _Project.Common.Services;
using _Project.Logic.Common.Ai;
using _Project.Logic.Common.Characters;
using _Project.Logic.Common.Services;
using UniRx;

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

            IDisposable disposable = null;
            disposable = character.IsAlive
                .Subscribe(isAlive =>
                {
                    if (!isAlive)
                        DisposeAi();
                });
            
            ActorsRepository.Register(aiActor);
            
            void DisposeAi()
            {
                ActorsRepository.Unregister(aiActor);
                disposable.Dispose();
            }
        }

        protected abstract IAiActor CreateAiActor(Character character);
    }
}