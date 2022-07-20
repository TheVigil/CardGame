using Manager;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using RND = System.Random;


namespace Data.Objects
{
    public class ArtistRuleCard : RuleCard, IAssignmentHelper
    {
        private List<string> _birthyearalloc;

        public ArtistRuleCard(int points, List<string> birthAllocation)
        {
            _points = points;
            _birthyearalloc = birthAllocation;
        }

        public void AssignRuleText(List<string> ruleText)
        {
            var _random = new RND();
            var i = _random.Next(0, ruleText.Count);
            var j = _random.Next(0, ruleText.Count);

            if (_birthyearalloc == null)
            {
                _birthyearalloc = new List<string>();
                _birthyearalloc.Add(ruleText[i]);
                _birthyearalloc.Add(ruleText[j]);

            }
            else
            {
                _birthyearalloc.Add(ruleText[i]);
                _birthyearalloc.Add(ruleText[j]);
            }

            // gameObject.transform.parent.GetComponentInChildren<RuleSign>().description = ruleText[i];
            if (ruleText[i] == ruleText[j])
            {
                gameObject.transform.parent.GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = "Geburt (Jahrhundert): " + ruleText[i] + "Jh";

            }
            else
            {
                gameObject.transform.parent.GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = "Geburt (Jahrhundert): " + ruleText[i] + "Jh" + " oder " + ruleText[j] + "Jh";
            }

        }

        public override void AssertRuleViolation()
        {
            foreach (ItemCard card in _assignedItems.Keys)
            {

                bool match = false;
                var birthCentury = (card.Artist.BirthYear + 100).ToString()[..2];
                if (birthCentury == _birthyearalloc[0] || birthCentury == _birthyearalloc[1] || birthCentury == "1")
                {
                    // note that if the birthCentury is a "1" this means there is no data in the dataset concerning the birth of the artist, so we give the player a freebie here
                    match = true;
                    
                }

                if (match)
                {
                    _assignedItems[card] = true;
                    _points = GameManager.GameManagerInstance.GetLevel();
                    _reachedPoints += _points;
                    GameManager.GameManagerInstance.CalcScore(this.Points);
                    continue;
                }
            }
        }

        public List<String> NameAllocation
        {
            get { return _birthyearalloc; }
        }
    }
}