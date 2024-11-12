using System.Collections.Generic;
using _Project.Logic.Common.UI;

namespace _Project.Logic.Common.Services
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