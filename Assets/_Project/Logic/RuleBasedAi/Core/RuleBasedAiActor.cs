using _Project.Logic.Common.Ai;

namespace _Project.RuleBasedAi.Core
{
    public class RuleBasedAiActor : IAiActor
    {
        private readonly IRule[] _rules;

        public RuleBasedAiActor(params IRule[] rules) => 
            _rules = rules;

        public void Update()
        {
            foreach (IRule rule in _rules)
            {
                if (rule.CanExecute)
                {
                    rule.Execute();
                    return;
                }
            }
        }
    }
}