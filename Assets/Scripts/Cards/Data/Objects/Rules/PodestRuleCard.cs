using System;

namespace Data.Objects
{
    public class PodestRuleCard : RuleCard
    {
        private RuleCard[] _allocatedRules;

        public PodestRuleCard(int points, RuleCard[] rules)
        {
            _points = points;
            _allocatedRules = rules;
        }

        public override void AssertRuleViolation()
        {
            foreach (RuleCard rule in _allocatedRules)
            {
                rule.AttachItemToRule(_assignedItems);
                rule.AssertRuleViolation();

                foreach (ItemCard card in rule.AssignedItems.Keys)
                    if (rule.AssignedItems[card])
                        _reachedPoints += Math.Round((double)_points / (_assignedItems.Count * _allocatedRules.Length), 1);
            }

            _reachedPoints = CorrectReachedPoints();
        }

        private double CorrectReachedPoints()
        {
            return (_reachedPoints < _points) ? _reachedPoints : _points;
        }

        public RuleCard[] Rules
        {
            get { return _allocatedRules; }
        }
    }
}