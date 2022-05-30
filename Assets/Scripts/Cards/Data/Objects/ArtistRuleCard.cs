namespace Data.Objects
{
    public class ArtistRuleCard : RuleCard
    {
        private string _nameAllocation;

        public ArtistRuleCard(int points, string nameAllocation)
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