using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using Cards;
using Data.Objects;
using UnityEngine.UI;

namespace Manager
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
        private static CardManager CardManagerInstance;
        public GameState gameState;
        #endregion

        // TODO: implement the individual bits of state for the manager. What states do we need here?
        public enum GameState
        {
            
            PlayerTurn,
            ScoreCalc,
            TurnEnd
        }   

        #region setup
        private void Awake()
        {
            GameManagerInstance = gameObject.GetComponent<GameManager>();
            CardManagerInstance = gameObject.GetComponent<CardManager>();
        }

        // Start is called before the first frame update
        void Start()
        {
            CardManagerInstance.PopulateDeck();
        }

        #endregion

        #region game state changes
        public void UpdateGameState(GameState newGameState)
        {
            // TODO: Implement handlers for state changes
            throw new System.NotImplementedException("Gamestate logic not implemented");

        }
        #endregion

        // Update is called once per frame
        void Update()
        {

        }
    }
}

