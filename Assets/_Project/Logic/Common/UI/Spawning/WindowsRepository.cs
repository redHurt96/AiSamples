using System.Collections.Generic;

namespace _Project.Common.UI.Spawning
{
    public class WindowsRepository
    {
        private readonly List<IWindow> _windows = new();
        
        public void Register(IWindow window) => 
            _windows.Add(window);

        public bool TryGetValue<T>(out T value)
        {
            value = (T)_windows.Find(x => x is T);
            return value != null;
        }
    }
}