namespace Data.Objects
{
    public class MatRuleCard : RuleCard
    {
        private List<string> _allocatedMaterials;

        public MatRuleCard(int points, List<string> materials)
        {
            _points = points;
            _allocatedMaterials = materials;
        }

        public override void AssertRuleViolation()
        {
            foreach (ItemCard card in _assignedItems.Keys)
            {
                foreach (string itemMat in card.Materials)
                {
                    bool match = false;

                    foreach (string ruleMat in _allocatedMaterials)
                    {
                        if (itemMat.Equals(ruleMat))
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

        public List<string> AllocatedMaterials
        {
            get { return _allocatedMaterials; }
        }
    }
}