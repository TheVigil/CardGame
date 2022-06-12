using System;

namespace Data.Objects
{
    public class ObjectRuleCard : RuleCard
    {
        private string[] _allocatedKeywords;

        public ObjectRuleCard(int points, string[] keywords)
        {
            _points = points;
            _allocatedKeywords = keywords;
        }

        public override void AssertRuleViolation()
        {
            foreach (ItemCard card in _assignedItems.Keys)
            {
                for (int i = 0; i < card.Keywords.Count; i++)
                {
                    bool match = false;

                    for (int j = 0; j < _allocatedKeywords.Length; j++)
                    {
                        if (card.Keywords[i].Equals(_allocatedKeywords[j]))
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

        public string[] AllocatedKeywords
        {
            get { return _allocatedKeywords; }
        }
    }
}