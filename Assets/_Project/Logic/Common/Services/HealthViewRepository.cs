using System.Collections.Generic;
using _Project.Common.UI.HealthBar;

namespace _Project.Common.Services
{
    public class HealthViewRepository
    {
        private readonly List<HealthView> _items = new();

        public void Register(HealthView value) => 
            _items.Add(value);

        public void Unregister(HealthView value) => 
            _items.Remove(value);
    }
}