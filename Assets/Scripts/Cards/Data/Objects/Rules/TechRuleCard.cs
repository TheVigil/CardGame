using System;
using System.Collections.Generic;
using TMPro;
using RND = System.Random;
using Manager;
namespace Data.Objects
{
    public class TechRuleCard : RuleCard, IAssignmentHelper
    {
        private List<string> _allocatedTechniques;

        public TechRuleCard(int points, List<string> techniques)
        {
            _points = points;
            _allocatedTechniques = techniques;
        }

        public void AssignRuleText(List<string> ruleText)
        {
            var _random = new RND();
            var i = _random.Next(0, ruleText.Count);

            if (_allocatedTechniques == null)
            {
                _allocatedTechniques = new List<string>();
                _allocatedTechniques.Add(ruleText[i]);

            }
            else
            {
                _allocatedTechniques.Add(ruleText[i]);
            }
            gameObject.transform.parent.GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = "Technik: " + ruleText[i];
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
                        _points = 1 * GameManager.GameManagerInstance.GetLevel();
                        _reachedPoints += _points;
                        GameManager.GameManagerInstance.CalcScore(this.Points);
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