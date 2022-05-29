using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cards;

namespace GameManager
{
    public class GameManager : MonoBehaviour
    {
        /*
        *
        *   This is a controller for managing the logic and mechanics of the game.
        *   Here we should e.g. draw cards, check rules, update scores etc.
        *   Keeping all gameflow in this singleton class is a Unity Best Practice.
        *   
        */

        #region declarations
        public static GameManager GameManagerInstance; // use this later to access gm from anywhere in our logic

        public enum GameState
        {
            // TODO: implement the individual bits of state for the manager. What states do we need here?
            PlayerTurn,
            ScoreCalc,
            TurnEnd
        }   

        public GameState gameState;
        public List<GameObject> deck = new List<GameObject>();
        public List<GameObject> discardPile = new List<GameObject>();
        public Transform[] cardSlots; // an array of transforms for tracking slot positions
        public bool[] availableCardSlots; // track if card slots are available for the player's hand
        public GameObject PlayerCard;

        #endregion

        #region setup
        private void Awake()
        {
            GameManagerInstance = this; // GameManager must be a singleton.
        }

        // Start is called before the first frame update
        void Start()
        {
            // TODO: we should call a factory method here to generate the cards/rules etc.
            PopulateDeck();
        }
        #endregion

        #region game state
        public void UpdateGameState(GameState newGameState)
        {
            // TODO: Implement handlers for state changes
            gameState = newGameState;

            switch (newGameState)
            {
                case GameState.PlayerTurn:
                    Invoke("DrawCard", 0f); // instantly draw a card at the top of the turn.
                    break;
                case GameState.ScoreCalc:
                    HandleScoreCalc();
                    break;
                default:
                    throw new System.NotImplementedException("Logic for handling gamestate changes not implemented");
            }

        }
        #endregion

        #region handlers and assorted methods
        private void PopulateDeck()
        {
            // TODO: Implement. Should fill the deck list with cards
            for (int i = 0; i < 60; i++)
            {
                GameObject Card = Instantiate(PlayerCard, new Vector2(0, 0), Quaternion.identity);
                deck.Add(Card);
            }
        }

        private void HandleScoreCalc()
        {
            // TODO: Implement. Should calculate score based on rules for each drop zone
            throw new System.NotImplementedException();
        }

        public void DrawCard()
        {
            if(deck.Count >= 1)
             {
                 GameObject randCard = deck[Random.Range(0, deck.Count + 1)];

                 for (int i = 0; i < availableCardSlots.Length; i++)
                 {
                     if (availableCardSlots[i] == true)
                     {
                         randCard.gameObject.SetActive(true);
                         randCard.transform.SetParent(cardSlots[i].transform, false);
                         randCard.GetComponent<Card>().handSlotIndex = i;
                         Debug.Log(randCard.GetComponent<Card>().handSlotIndex);
                         availableCardSlots[i] = false;
                         deck.Remove(randCard);
                         return; //draw only one card
                     }
                 }
             }           
        }
        #endregion


        // Update is called once per frame
        void Update()
        {

        }
    }
}

