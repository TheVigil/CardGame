using System;
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
        private static SceneLoader SceneLoader;
        private static LevelManager LevelManager;
        private static RuleManager RuleManager;
        internal int CurrentLevel;

        public GameState gameState;
        public static event Action<GameState> OnGameStateChanged;

        // TODO: implement the individual bits of state for the manager. What states do we need here?
        public enum GameState
        {
            StartGame,
            PlayerTurn,
            UpdateScore,
            UpdateLevelNumber,
            TurnEnd,
            LevelEnd,
        }
        #endregion

        #region Unity Methods
        private void Awake()
        {

            CurrentLevel = 0;

            if (GameManagerInstance != null)
            {
                Destroy(this);
            }
            else
            {
                GameManagerInstance = this;
                LevelManager = GetComponent<LevelManager>();
                SceneLoader = GetComponent<SceneLoader>();
                CardManagerInstance = GetComponent<CardManager>();
                RuleManager = GetComponent<RuleManager>();
                GameObject.Find("RulesTextDisplay").SetActive(false);
            }

            //TODO: there's a better way for sure
            DontDestroyOnLoad(GameManagerInstance);
            DontDestroyOnLoad(CardManagerInstance);
            DontDestroyOnLoad(SceneLoader);
            DontDestroyOnLoad(LevelManager);
            DontDestroyOnLoad(RuleManager);
            DontDestroyOnLoad(GameObject.Find("CardSlots"));
            DontDestroyOnLoad(GameObject.Find("CardContainer"));
            DontDestroyOnLoad(GameObject.Find("Canvas"));
        }

        // Start is called before the first frame update
        void Start()
        {
            CardManagerInstance.PopulateDeck();
            UpdateGameState(GameState.StartGame);
        }

        // Update is called once per frame
        void Update()
        {

        }

        void SaveObject()
        {
            
        }
        #endregion

        #region State Management

        // TODO: For debugging only, delete!
        public void ForceScene()
        {
            UpdateGameState(GameState.LevelEnd);
        }

        public void UpdateGameState(GameState newGameState)
        {
            gameState = newGameState;
            // TODO: Implement handlers for state changes
            switch (newGameState)
            {
                case GameState.StartGame:
                    LevelManager.UpdateLevelState(LevelManager.LevelState.setUp);
                    RuleManager.UpdateRuleState(RuleManager.RuleState.assignRules);
                    break;
                case GameState.PlayerTurn:
                    break;
                case GameState.UpdateScore:
                    UpdateScore();
                    break;
                case GameState.UpdateLevelNumber:
                    UpdateLevelNumber();
                    break;
                case GameState.TurnEnd:
                    break;
                case GameState.LevelEnd:
                    RuleManager.UpdateRuleState(RuleManager.RuleState.checkRules);
                    SceneLoader.UpdateSceneState(SceneLoader.SceneState.nextScene);
                    LevelManager.UpdateLevelState(LevelManager.LevelState.setUp);
                    break;
                default:
                    break;
            }

            OnGameStateChanged?.Invoke(newGameState);
        }
        #endregion

        #region Methods

        private void UpdateScore()
        {
            throw new NotImplementedException();
        }

        private void UpdateLevelNumber()
        {
            CurrentLevel++;
        }
        #endregion

    }
}

