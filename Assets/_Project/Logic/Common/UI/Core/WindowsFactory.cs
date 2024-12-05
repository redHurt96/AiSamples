using UnityEngine;
using Zenject;

namespace _Project.Common.UI.Core
{
    public class WindowsFactory
    {
        private readonly Transform _canvas;
        private readonly WindowsRepository _repository;
        private readonly IInstantiator _instantiator;

        public WindowsFactory(Transform canvas, WindowsRepository repository, IInstantiator instantiator)
        {
            _canvas = canvas;
            _repository = repository;
            _instantiator = instantiator;
        }

        public IWindow<TViewModel> Create<TView, TViewModel>() where TView : MonoBehaviour, IWindow<TViewModel>
        {
            if (_repository.TryGetValue(out TView value))
                return value;

            TViewModel viewModel = _instantiator.Instantiate<TViewModel>();
            
            TView view = _instantiator.InstantiatePrefabResourceForComponent<TView>(
                typeof(TView).Name, 
                _canvas);
                
            view.Setup(viewModel);
            _repository.Register(view);

            return view;
        }
    }
}