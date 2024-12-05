using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace _Project.Common.UI.Core
{
    public abstract class Window<T> : MonoBehaviour, IWindow<T>
    {
        protected T ViewModel;
        private IWindowAnimator _animator;

        public void Setup(T viewModel)
        {
            ViewModel = viewModel;
            
            if (ViewModel is IInitializable initializable)
                initializable.Initialize();

            if (!TryGetComponent(out _animator))
                _animator = gameObject.AddComponent<InstantAnimator>();
        }

        private void OnDestroy()
        {
            if (ViewModel is IDisposable disposable)
                disposable.Dispose();
        }

        public async UniTask Show()
        {
            Block();
            _animator.Prepare();
            await _animator.Show(); 
            Unblock();
        }

        public async UniTask Hide()
        {
            Block();
            await _animator.Hide();
        }

        protected abstract void Block();

        protected abstract void Unblock();
    }
}