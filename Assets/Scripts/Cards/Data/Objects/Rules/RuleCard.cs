using System;
using System.Collections.Generic;
using UnityEngine;

namespace Data.Objects
{
    public abstract class RuleCard : Card
    {
        protected int _points;
        protected double _reachedPoints;
        protected Dictionary<ItemCard, bool> _assignedItems;

        public RuleCard()
        {
            _assignedItems = new Dictionary<ItemCard, bool>();
        }

        public abstract void AssertRuleViolation();

        private void InitAssignedItems(ItemCard card)
        {
            if( _assignedItems == null)
            {
                _assignedItems = new Dictionary<ItemCard, bool>();
                _assignedItems.Add(card, false);
            }
            else
            {
                return;
            }
        }
        public void AttachItemToRule(ItemCard card)
        {
            if( _assignedItems != null)
            {
                _assignedItems.Add(card, false);
            }
            else
            {
                InitAssignedItems(card);
            }
        }

        public void AttachItemToRule(Dictionary<ItemCard, bool> cards)
        {
            foreach (KeyValuePair<ItemCard, bool> card in cards)
                _assignedItems.Add(card.Key, card.Value);
        }

        public void DetatchItemFromRule(ItemCard card)
        {
            _assignedItems.Remove(card);
        }

        public int Points
        {
            get { return _points; }
        }

        public double ReachedPoints
        {
            get { return _reachedPoints; }
        }

        public int MaxPoints
        {
            get { return _points * _assignedItems.Count; }
        }

        public Dictionary<ItemCard, bool> AssignedItems
        {
            get { return _assignedItems; }
        }
    }
}