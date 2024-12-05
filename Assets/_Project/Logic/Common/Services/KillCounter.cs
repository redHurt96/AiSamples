using System;
using System.Collections.Generic;
using _Project.Common.Characters.Model;
using UniRx;
using Zenject;

namespace _Project.Common.Services
{
    public class KillCounter : IInitializable, IDisposable
    {
        private readonly CharactersFactory _charactersFactory;
        public ISubject<KillEventData> OnKill => _onKill;
        
        private readonly Subject<KillEventData> _onKill = new();
        private readonly CompositeDisposable _disposable = new();
        private readonly Dictionary<Character,IDisposable> _killSubscriptions = new();

        public KillCounter(CharactersFactory charactersFactory) => 
            _charactersFactory = charactersFactory;

        public void Initialize() =>
            _charactersFactory.Created
                .Subscribe(SubscribeOn)
                .AddTo(_disposable);

        public void Dispose() => 
            _disposable.Dispose();

        private void SubscribeOn(Character character)
        {
            CompositeDisposable disposable = new();
            _killSubscriptions.Add(character, disposable);
            
            character.OnKill
                .Subscribe(_onKill.OnNext)
                .AddTo(_disposable);

            character.IsAlive
                .Where(x => !x)
                .Subscribe(_ =>
                {
                    _killSubscriptions[character].Dispose();
                    _killSubscriptions.Remove(character);
                })
                .AddTo(_disposable);
        }
    }
}