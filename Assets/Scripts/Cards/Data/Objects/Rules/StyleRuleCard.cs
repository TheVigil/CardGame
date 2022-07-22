using Manager;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using RND = System.Random;
namespace Data.Objects
{
    public class StyleRuleCard : RuleCard, IAssignmentHelper
    {
        private List<string> _styleAllocation;

        public StyleRuleCard(int points, List<string> styleName)
        {
            _points = points;
            _styleAllocation = styleName;
        }

        public void AssignRuleText(List<string> ruleText)
        {
            var _random = new RND();
            var i = _random.Next(0, ruleText.Count);

            if (_styleAllocation == null)
            {
                _styleAllocation = new List<string>();
                _styleAllocation.Add(ruleText[i]);

            }
            else
            {
                _styleAllocation.Add(ruleText[i]);
            }
            gameObject.transform.parent.GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = "Einordnung: " + ruleText[i];
        }

        public override void AssertRuleViolation()
        {
            foreach (ItemCard card in _assignedItems.Keys)
            {
                if (card.HistClass == _styleAllocation[0])
                {
                    _points = 1 * GameManager.GameManagerInstance.GetLevel();
                    _reachedPoints += _points;
                    GameManager.GameManagerInstance.CalcScore(this.Points);
                    continue;
                }

            }
                
        }

        public List<string> StyleAllocation
        {
            get { return _styleAllocation; }
        }
    }
}