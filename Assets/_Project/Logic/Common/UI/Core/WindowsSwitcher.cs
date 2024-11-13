using UnityEngine;

namespace _Project.Common.UI.Core
{
    public class WindowsSwitcher
    {
        private IWindow _current;
        
        private readonly WindowsFactory _windowsFactory;

        public WindowsSwitcher(WindowsFactory windowsFactory)
        {
            _windowsFactory = windowsFactory;
        }

        public void Show<T>() where T : MonoBehaviour, IWindow
        {
            if (_current != null)
                _current.Hide();

            _current = Get<T>();
            _current.Show();
        }

        private IWindow Get<T>() where T : MonoBehaviour, IWindow => 
            _windowsFactory.Create<T>();
    }
}