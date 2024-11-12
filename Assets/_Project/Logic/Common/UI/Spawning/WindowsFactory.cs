using UnityEngine;
using static UnityEngine.Object;
using static UnityEngine.Resources;

namespace _Project.Common.UI.Spawning
{
    public class WindowsFactory
    {
        private WindowsSwitcher _windowsSwitcher;
        
        private readonly Transform _canvas;
        private readonly WindowsRepository _repository;
        private readonly Spawner _spawner;

        public WindowsFactory(Transform canvas, WindowsRepository repository, Spawner spawner)
        {
            _canvas = canvas;
            _repository = repository;
            _spawner = spawner;
        }

        public void InstallWindowsSwitcher(WindowsSwitcher windowsSwitcher) => 
            _windowsSwitcher = windowsSwitcher;

        public IWindow Create<T>() where T : MonoBehaviour, IWindow
        {
            if (_repository.TryGetValue(out T value))
                return value;
            
            if (typeof(T) == typeof(Hud))
                return CreateHud();
            
            if (typeof(T) == typeof(SpawnWindow))
                return CreateSpawnWindow();
            
            throw new($"There is no method for window type {typeof(T).Name}");
        }

        private Hud CreateHud()
        {
            HudViewModel viewModel = new(_windowsSwitcher);
            Hud instance = CreateView<Hud>();
            
            instance.Construct(viewModel);
            return instance;
        }

        private SpawnWindow CreateSpawnWindow()
        {
            SpawnViewModel viewModel = new(_spawner, _windowsSwitcher);
            SpawnWindow instance = CreateView<SpawnWindow>();
            
            instance.Construct(viewModel);
            return instance;
        }

        private T CreateView<T>() where T : Object, IWindow
        {
            T resource = Load<T>(typeof(T).Name);
            T instance = Instantiate(resource, _canvas.position, Quaternion.identity, _canvas);
            _repository.Register(instance);
            
            return instance;
        }
    }
}