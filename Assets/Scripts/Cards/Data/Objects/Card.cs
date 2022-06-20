using System;
using System.Collections.Generic;
using UnityEngine;
using Manager;

namespace Data.Objects
{
    public class Card : MonoBehaviour
    {
        public bool played;
        public int handSlotIndex;
        private GameManager gameManager;
        private CardFlipper flipper;
        private bool showFace;
        public List<Sprite> sprites;
        internal int cardIndex;
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

        private void Start()
        {

            gameManager = FindObjectOfType<GameManager>();
            flipper = gameObject.AddComponent<CardFlipper>();
        }

        private void Update()
        {

        }

        public void OnDrop()
        {
            if (played)
            {
                gameManager.GetComponent<CardManager>().availableCardSlots[handSlotIndex] = true;
            }
        }

    }
}