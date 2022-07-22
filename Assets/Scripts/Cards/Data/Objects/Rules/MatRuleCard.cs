using System;
using System.Collections.Generic;
using UnityEngine;
using RND = System.Random;
using Manager;
using TMPro;

namespace Data.Objects
{
    public class MatRuleCard : RuleCard, IAssignmentHelper
    {
        private List<string> _allocatedMaterials;

        public MatRuleCard(int points, List<string> materials)
        {
            _points = points;
            _allocatedMaterials = materials;
        }

        public void AssignRuleText(List<string> ruleText)
        {
            var _random = new RND();
            var i = _random.Next(0, ruleText.Count);

            if(_allocatedMaterials == null)
            {
                _allocatedMaterials = new List<string>();
                _allocatedMaterials.Add(ruleText[i]);

            }
            else
            {
                _allocatedMaterials.Add(ruleText[i]);
            }
            gameObject.transform.parent.GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = "Material: " + ruleText[i];
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
                        if (itemMat.ToLower().Contains(ruleMat.ToLower()))
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

        public List<string> AllocatedMaterials
        {
            get { return _allocatedMaterials; }
        }
    }
}