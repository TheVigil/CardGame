using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using Cards;
using Data.Objects;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        public int CurrentPoints = 0;

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
                // GameObject.Find("RulesTextDisplay").SetActive(false);
            }

            DontDestroyOnLoad(GameManagerInstance);
            DontDestroyOnLoad(CardManagerInstance);
            DontDestroyOnLoad(SceneLoader);
            DontDestroyOnLoad(LevelManager);
            DontDestroyOnLoad(RuleManager);
            DontDestroyOnLoad(GameObject.Find("CardSlots"));
            DontDestroyOnLoad(GameObject.Find("CardContainer"));
            DontDestroyOnLoad(GameObject.Find("Canvas"));

            SceneManager.sceneLoaded += OnSceneLoaded;

        }

        // Start is called before the first frame update
        void Start()
        {
            CardManagerInstance.PopulateDeck();
            UpdateGameState(GameState.StartGame);
        }

        #endregion

        #region State Management

        // TODO: For debugging only, delete!
        public void ForceScene()
        {
            SceneLoader.LoadScene();
        }

        public void UpdateGameState(GameState newGameState)
        {
            gameState = newGameState;

            switch (newGameState)
            {
                case GameState.StartGame:
                    LevelManager.UpdateLevelState(LevelManager.LevelState.setUp);
                    RuleManager.UpdateRuleState(RuleManager.RuleState.assignRules, gameObject.transform, gameObject);
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
                   // RuleManager.UpdateRuleState(RuleManager.RuleState.checkRules, gameObject.transform, gameObject);
                    SceneLoader.UpdateSceneState(SceneLoader.SceneState.nextScene);
                    LevelManager.UpdateLevelState(LevelManager.LevelState.setUp);
                    // RuleManager.UpdateRuleState(RuleManager.RuleState.assignRules, gameObject.transform, gameObject);
                    break;
                default:
                    break;
            }

            OnGameStateChanged?.Invoke(newGameState);
        }
        #endregion

        #region Methods

        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            Debug.Log("OnSceneLoaded: " + scene.name);
            RuleManager.UpdateRuleState(RuleManager.RuleState.assignRules, gameObject.transform, gameObject);
        }

        private void UpdateScore()
        {
            throw new System.NotImplementedException();
        }

        public int GetLevel()
        {
            return LevelManager.CurrentLevel;
        }

        public int CalcScore(int points)
        {
            Debug.Log("Incoming Score: " + points);
            CurrentPoints += points;
            Debug.Log("Curr Score: " + CurrentPoints);
            return CurrentPoints;
        }

        private void UpdateLevelNumber()
        {
            CurrentLevel++;
        }
        #endregion

    }
}

