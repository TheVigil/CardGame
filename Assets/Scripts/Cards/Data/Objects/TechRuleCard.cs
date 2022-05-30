namespace Data.Objects
{
    public class TechRuleCard : RuleCard
    {
        private List<string> _allocatedTechniques;

        public TechRuleCard(int points, List<string> techniques)
        {
            _points = points;
            _allocatedTechniques = techniques;
        }

        public override void AssertRuleViolation()
        {
            foreach (ItemCard card in _assignedItems.Keys)
            {
                foreach (string itemTech in card.Techniques)
                {
                    bool match = false;

                    foreach (string ruleTech in _allocatedTechniques)
                    {
                        if (itemTech.Equals(ruleTech))
                        {
                            match = true;
                            break;
                        }
                    }

                    if (match)
                    {
                        _assignedItems[card] = true;
                        _reachedPoints += _points;
                        break;
                    }
                }
            }
        }

        public List<string> AllocatedTechniques
        {
            get { return _allocatedTechniques; }
        }
    }
}