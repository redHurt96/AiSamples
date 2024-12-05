using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Project.Common.UI.Core
{
    public abstract class WindowsSwitcher
    {
        private IWindow _current;
        
        private readonly WindowsFactory _windowsFactory;
        private UniTask _openAnimation;

        protected WindowsSwitcher(WindowsFactory windowsFactory) => 
            _windowsFactory = windowsFactory;

        protected async void Show<TView, TViewModel>() where TView : MonoBehaviour, IWindow<TViewModel>
        {
            if (_openAnimation.Status is UniTaskStatus.Succeeded)
                await _openAnimation;
            
            if (_current != null)
                await _current.Hide();

            _current = _windowsFactory.Create<TView, TViewModel>();
            _openAnimation = _current.Show();
        }
    }
}