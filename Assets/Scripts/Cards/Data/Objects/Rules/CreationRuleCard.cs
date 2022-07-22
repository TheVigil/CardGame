using Manager;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using RND = System.Random;
namespace Data.Objects
{
    public class CreationRuleCard : RuleCard, IAssignmentHelper
    {
        private int _creationAllocation;
        private int _allowedDeviation;
        private List<string> _centuryAllocation;

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

        public void AssignRuleText(List<string> ruleText)
        {
            var _random = new RND();
            var i = _random.Next(0, ruleText.Count);

            if (_centuryAllocation == null)
            {
                _centuryAllocation = new List<string>();
                _centuryAllocation.Add(ruleText[i]);

            }
            else
            {
                _centuryAllocation.Add(ruleText[i]);
            }
            gameObject.transform.parent.GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = "Entstehungsjahrhundert: " + ruleText[i];
        }

        public override void AssertRuleViolation()
        {
            foreach (ItemCard card in _assignedItems.Keys)
            {
                bool match = false;
                var creationCentury = (card.Artist.BirthYear + 100).ToString()[..2];

                if (creationCentury == _centuryAllocation[0])
                {
                    match = true;
                }

                if (match)
                {
                    _points = 1 * GameManager.GameManagerInstance.GetLevel();
                    _reachedPoints += _points;
                    GameManager.GameManagerInstance.CalcScore(this.Points);
                    continue;
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