using UnityEngine;

namespace Data.Objects
{
    public class Card : MonoBehaviour 
    {

        
        public bool played;
        public int handSlotIndex; 
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

        private void Start()
        {

            gameManager = GameObject.FindObjectOfType<GameManager.GameManager>();

        }

        public void OnDrop()
        {
            if (this.played)
            {
                gameManager.availableCardSlots[handSlotIndex] = true;
            }
        }

        private void Update()
        {

        }
    }
}