using System;
using _Project.Common.Characters.Model;
using _Project.Logic.Common.Characters;
using _Project.Logic.Common.UI;
using UniRx;
using UnityEngine;
using static UnityEngine.Object;
using static UnityEngine.Quaternion;
using static UnityEngine.Resources;

namespace _Project.Logic.Common.Services
{
    public class HealthViewFactory
    {
        private readonly HealthViewRepository _healthViewRepository;
        private readonly Transform _parent;
        private readonly Camera _camera;

        public HealthViewFactory(HealthViewRepository healthViewRepository, Transform parent, Camera camera)
        {
            _healthViewRepository = healthViewRepository;
            _parent = parent;
            _camera = camera;
        }

        public void Create(Health health, HealthViewAnchor anchor)
        {
            HealthView resourse = Load<HealthView>("HealthView");
            HealthViewModel healthViewModel = new(health, _camera, anchor);
            HealthView instance = Instantiate(resourse, _parent.position, identity, _parent);

            instance.Construct(healthViewModel);
            _healthViewRepository.Register(instance);
            
            IDisposable disposable = null;
            disposable = health.IsAlive.Subscribe(isAlive =>
            {
                if (!isAlive)
                    Unregister();
            });

            void Unregister()
            {
                Destroy(instance.gameObject);
                _healthViewRepository.Unregister(instance);
                disposable.Dispose();
            }
        }

    }
}