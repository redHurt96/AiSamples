using System;
using _Project.Common.Characters.Model;
using _Project.Logic.Common.Characters;
using _Project.Logic.Common.Services;
using _Project.Logic.Common.UI;
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
        private const float SPAWN_DISTANCE = 20f;

        private float RandomDistance => Range(-SPAWN_DISTANCE, SPAWN_DISTANCE);
        
        private readonly CharactersRepository _charactersRepository;
        private readonly HealthViewFactory _healthViewFactory;

        public CharactersFactory(CharactersRepository charactersRepository, HealthViewFactory healthViewFactory)
        {
            _charactersRepository = charactersRepository;
            _healthViewFactory = healthViewFactory;
        }

        internal Character Create()
        {
            Character resourse = Load<Character>("Character");
            Vector3 position = new(RandomDistance, 0f, RandomDistance);
            Character instance = Instantiate(resourse, position, Quaternion.identity);
            int team = Range(0, 3);

            instance.Construct(team);
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
