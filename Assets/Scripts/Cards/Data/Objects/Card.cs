using System;
using System.Collections;
using System.Drawing;
using Unity;
using UnityEngine;

namespace Data.Objects
{
    public class Card : MonoBehaviour 
    {

        // TODO: could be that we need separate logic for cards, so I just went ahead and set up a template class. . .
        public bool played; // track if the card has already been played by the player

        public int handSlotIndex; // track the index of the handslot in which this card is located
        private GameManager.GameManager gameManager;

        protected readonly double _pixHeight = 50.0;
        protected readonly double _pixWidth = 30.0;

        public double PixHeight
        {
            get { return _pixHeight; }
        }

        public double PixWidth
        {
            get { return _pixWidth; }
        }
    }
}