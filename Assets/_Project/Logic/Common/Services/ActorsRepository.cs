using System.Collections.Generic;
using _Project.Common.Ai;

namespace _Project.Common.Services
{
    public class ActorsRepository
    {
        public IEnumerable<IAiActor> All => _actors;
        
        private readonly List<IAiActor> _actors = new();

        public void Register(IAiActor aiActor) => 
            _actors.Add(aiActor);

        public void Unregister(IAiActor aiActor) => 
            _actors.Remove(aiActor);
    }
}