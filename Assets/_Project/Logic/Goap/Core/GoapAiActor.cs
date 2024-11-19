using System.Collections.Generic;
using System.Linq;
using _Project.Common.Ai;

namespace _Project.Goap.Core
{
    public class GoapAiActor<T> : IAiActor where T : IContext
    {
        private readonly T _context;
        private readonly Plan<T> _plan = new();
        private readonly IGoal<T>[] _goals;
        private readonly IAction<T>[] _actions;

        public GoapAiActor(T context, IGoal<T>[] goals, IAction<T>[] actions)
        {
            _context = context;
            _goals = goals;
            _actions = actions;
        }

        public void Update()
        {
            _context.Update();
            
            if (_plan.Exist)
                _plan.Execute(_context);
            else
                CreatePlan();
        }

        private void CreatePlan()
        {
            Queue<IAction<T>> plan = new();
            
            foreach (IGoal<T> goal in _goals.OrderByDescending(x => x.Priority(_context)))
            {
                CreatePlan(goal, _context, _actions, plan);

                if (plan.Count > 0)
                    break;
            }
        }

        private void CreatePlan(IGoal<T> goal, T forContext, IEnumerable<IAction<T>> possibleActions, Queue<IAction<T>> plan)
        {
            if (_plan.Exist)
                return;
            
            foreach (IAction<T> action in possibleActions)
            {
                if (action.CanExecute(forContext))
                {
                    T context = (T)forContext.Copy();
                    Queue<IAction<T>> newPlan = new(plan);
                    
                    action.MockExecute(context);
                    newPlan.Enqueue(action);

                    if (goal.IsAchieved(context))
                    {
                        _plan.Fill(newPlan);
                        return;
                    }
                    
                    CreatePlan(goal, context, possibleActions.Where(x => x != action), newPlan);
                }
            }
        }
    }
}