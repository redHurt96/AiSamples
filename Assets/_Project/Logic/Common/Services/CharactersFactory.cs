using System;
using _Project.Common.Characters.Model;
using _Project.Common.UI.HealthBar;
using UniRx;
using UnityEngine;
using static UnityEngine.Object;
using static UnityEngine.Random;
using static UnityEngine.Resources;
using Object = UnityEngine.Object;

namespace _Project.Common.Services
{
    public class CharactersFactory
    {
        public ISubject<Character> Created => _created;
        
        private readonly Subject<Character> _created = new();

        private const float SPAWN_DISTANCE = 20f;

        private float RandomDistance => Range(-SPAWN_DISTANCE, SPAWN_DISTANCE);
        
        private readonly CharactersRepository _charactersRepository;
        private readonly HealthViewFactory _healthViewFactory;
        private readonly FreezeEffectFactory _freezeEffectFactory;

        public CharactersFactory(
            CharactersRepository charactersRepository, 
            HealthViewFactory healthViewFactory,
            FreezeEffectFactory freezeEffectFactory)
        {
            _charactersRepository = charactersRepository;
            _healthViewFactory = healthViewFactory;
            _freezeEffectFactory = freezeEffectFactory;
        }

        internal Character Create(int teamId)
        {
            Character resourse = Load<Character>("Character");
            Vector3 position = new(RandomDistance, 0f, RandomDistance);
            Character instance = Instantiate(resourse, position, Quaternion.identity);

            instance.Construct(teamId);
            _charactersRepository.Register(instance);
            IDisposable disposable = null;
            disposable = instance.IsAlive
                .Subscribe(isAlive =>
                {
                    if (!isAlive)
                    {
                        Destroy();
                    }
                });

            _healthViewFactory.Create(
                instance.GetComponent<Health>(),
                instance.GetComponentInChildren<HealthViewAnchor>());
            
            _freezeEffectFactory.Create(instance, instance.GetComponent<FreezeEffect>());
            
            Created.OnNext(instance);
            
            return instance;

            void Destroy()
            {
                _charactersRepository.Unregister(instance);
                Object.Destroy(instance.gameObject);
                disposable.Dispose();
            }
        }
        
    }
}
