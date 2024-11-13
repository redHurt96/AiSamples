using _Project.Common.Ai;

namespace _Project.Logic.UtilityAi.Core
{
    public class UtilityAiActor : IAiActor
    {
        private readonly IAction[] _actions;

        public UtilityAiActor(params IAction[] actions) => 
            _actions = actions;

        public void Update()
        {
            float maxEfficiency = float.MinValue;
            IAction mostEfficient = null;
            
            foreach (IAction action in _actions)
            {
                float efficiency = action.Efficiency;

                if (efficiency > maxEfficiency)
                {
                    maxEfficiency = efficiency;
                    mostEfficient = action;
                }
            }
            
            mostEfficient!.Act();
        }
    }
}