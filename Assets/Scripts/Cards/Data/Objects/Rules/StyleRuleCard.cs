using System;

namespace Data.Objects
{
    public class StyleRuleCard : RuleCard
    {
        private string _nameAllocation;

        public StyleRuleCard(int points, string nameAllocation)
        {
            _points = points;
            _nameAllocation = nameAllocation;
        }

        public override void AssertRuleViolation()
        {
            foreach (ItemCard card in _assignedItems.Keys)
                if (card.Artist.Name == _nameAllocation)
                {
                    _assignedItems[card] = true;
                    _reachedPoints += _points;
                }
        }

        public string NameAllocation
        {
            get { return _nameAllocation; }
        }
    }
}