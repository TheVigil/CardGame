using System;
using System.Collections.Generic;
using UnityEngine;

namespace Data.Objects
{
    public class Card : MonoBehaviour 
    {

        
        public bool played;
        public int handSlotIndex; 
        private GameManager.GameManager gameManager;
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

            gameManager = GameObject.FindObjectOfType<GameManager.GameManager>();
            flipper = gameObject.AddComponent<CardFlipper>();
            ToggleFace(false);
        }

        private void Update()
        {

        }

        public void OnDrop()
        {
            if (this.played)
            {
                gameManager.availableCardSlots[handSlotIndex] = true;
            }
        }

        internal void ToggleFace(bool v)
        {
            showFace = v;
        }
    }
}