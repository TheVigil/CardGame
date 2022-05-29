using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cards
{
    public class Card : MonoBehaviour
    {

        // TODO: could be that we need separate logic for cards, so I just went ahead and set up a template class. . .
        public bool played; // track if the card has already been played by the player

        public int handSlotIndex; // track the index of the handslot in which this card is located
        private GameManager.GameManager gameManager;

        // Start is called before the first frame update
        void Start()
        {
            gameManager = FindObjectOfType<GameManager.GameManager>();
        }

        // TODO: card logic here

        // Update is called once per frame
        void Update()
        {

        }
    }
}
