using _Project.Logic.Common.Characters;
using UnityEngine;
using static UnityEngine.Object;
using static UnityEngine.Random;
using static UnityEngine.Resources;

namespace _Project.Logic.Common.Services
{
    public class CharactersFactory
    {
        private const float SPAWN_DISTANCE = 20f;

        private float RandomDistance => Range(-SPAWN_DISTANCE, SPAWN_DISTANCE);
        
        private readonly CharactersRepository _charactersRepository;

        public CharactersFactory(CharactersRepository charactersRepository) => 
            _charactersRepository = charactersRepository;

        public Character Create()
        {
            Character resourse = Load<Character>("Character");
            Vector3 position = new(RandomDistance, 0f, RandomDistance);
            Character instance = Instantiate(resourse, position, Quaternion.identity);
            int team = Range(0, 3);

            instance.Construct(team);
            _charactersRepository.Register(instance);
            instance.Died += Destroy;
            
            return instance;

            void Destroy()
            {
                instance.Died -= Destroy;
                _charactersRepository.Unregister(instance);
                Object.Destroy(instance.gameObject);
            }
        }
        
    }
}
