using System;

namespace Data.Objects
{
    public class CreationRuleCard : RuleCard
    {
        private int _creationAllocation;
        private int _allowedDeviation;

        public CreationRuleCard(int points, int yearAllocation, int allowedDeviation = 0)
        {
            _points = points;
            _creationAllocation = AssertCreationEstimation(yearAllocation);
            _allowedDeviation = allowedDeviation;
        }

        private int AssertCreationEstimation(int allocation)
        {
            int currYear = DateTime.Now.Year;

            if (allocation.ToString().Length == 4 && allocation <= currYear)
                return allocation;
            else
                throw new ArgumentException("Given year must be 4 digits in length and cannot be in the future");
        }

        public override void AssertRuleViolation()
        {
            foreach (ItemCard card in _assignedItems.Keys)
            {
                bool inRange = false;

                if (card.CreationTime.Count > 1)
                    inRange = CheckTimeRange(card.CreationTime[0], card.CreationTime[1]);
                else
                    inRange = CheckTimeRange(card.CreationTime[0], card.CreationTime[0]);

                if (inRange)
                {
                    _assignedItems[card] = true;
                    _reachedPoints += _points;
                }
            }
        }

        private bool CheckTimeRange(int from, int to)
        {
            return from - _allowedDeviation <= _creationAllocation && _creationAllocation <= to + _allowedDeviation;
        }

        public int CreationAllocation
        {
            get { return _creationAllocation; }
        }

        public int AllowedDeviation
        {
            get { return _allowedDeviation; }
        }
    }
}