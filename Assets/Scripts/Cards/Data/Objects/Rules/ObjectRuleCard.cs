using System;
using System.Collections.Generic;
using UnityEngine;
using RND = System.Random;
using Manager;
using TMPro;

namespace Data.Objects
{
    public class ObjectRuleCard : RuleCard, IAssignmentHelper
    {
        private List<string> _allocatedKeywords;

        public ObjectRuleCard(int points, List<string> keywords)
        {
            _points = points;
            _allocatedKeywords = keywords;
        }

        public void AssignRuleText(List<string> ruleText)
        {
            var _random = new RND();
            var i = _random.Next(0, ruleText.Count);
            var j = _random.Next(0, ruleText.Count);
            var k = _random.Next(0, ruleText.Count);

            if (_allocatedKeywords == null)
            {
                _allocatedKeywords = new List<string>();
                _allocatedKeywords.Add(ruleText[i]);
                _allocatedKeywords.Add(ruleText[j]);
                _allocatedKeywords.Add(ruleText[k]);

            }
            else
            {
                _allocatedKeywords.Add(ruleText[i]);
                _allocatedKeywords.Add(ruleText[j]);
                _allocatedKeywords.Add(ruleText[k]);
            }

            gameObject.transform.parent.GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = "Motiv: " + ruleText[i] + ", " + ruleText[j] + ", " + ruleText[k];
        }

        public override void AssertRuleViolation()
        {
            foreach (ItemCard card in _assignedItems.Keys)
            {
                for (int i = 0; i < card.Keywords.Count; i++)
                {
                    bool match = false;

                    for (int j = 0; j < _allocatedKeywords.Count; j++)
                    {
                        if (card.Keywords[i].Equals(_allocatedKeywords[j]))
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

        public List<string> AllocatedKeywords
        {
            get { return _allocatedKeywords; }
        }
    }
}