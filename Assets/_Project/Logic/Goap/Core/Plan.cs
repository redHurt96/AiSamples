using System.Collections.Generic;

namespace _Project.Goap.Core
{
    public class Plan<T> where T : IContext
    {
        public bool Exist => _plan.Count > 0;
        
        private Queue<IAction<T>> _plan = new();

        public void Execute(T forContext)
        {
            IAction<T> currentAction = _plan.Peek();
            
            if (currentAction.NeedToBreakPlan(forContext))
            {
                _plan.Clear();
                return;
            }
            
            if (currentAction.CanExecute(forContext))
                currentAction.Execute(forContext);
            else
                _plan.Dequeue();
        }

        public void Fill(Queue<IAction<T>> actions) => 
            _plan = actions;
    }
}