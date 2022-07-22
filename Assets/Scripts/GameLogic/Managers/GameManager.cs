using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using Cards;
using Data.Objects;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

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
        private static GameObject Canvas;
        private static GameObject CardSlots;
        private static GameObject CardContainer;
        private TextMeshProUGUI ScoreText;
        internal int CurrentLevel;
        public int CurrentPoints = 0;

        public GameState gameState;
        public static event Action<GameState> OnGameStateChanged;

        public enum GameState
        {
            StartGame,
            PlayerTurn,
            UpdateScore,
            UpdateLevelNumber,
            TurnEnd,
            LevelEnd,
            RestartGame
        }
        #endregion

        #region Unity Methods
        private void Awake()
        {
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
                ScoreText = GameObject.Find("ScoreText").GetComponentInChildren<TextMeshProUGUI>();
                CardSlots = GameObject.Find("CardSlots");
                CardContainer = GameObject.Find("CardContainer");
                Canvas = GameObject.Find("Canvas");
            }

            CurrentLevel = LevelManager.CurrentLevel;

            DontDestroyOnLoad(GameManagerInstance);
            DontDestroyOnLoad(CardManagerInstance);
            DontDestroyOnLoad(SceneLoader);
            DontDestroyOnLoad(LevelManager);
            DontDestroyOnLoad(RuleManager);
            DontDestroyOnLoad(CardSlots);
            DontDestroyOnLoad(CardSlots);
            DontDestroyOnLoad(Canvas);
           // DontDestroyOnLoad(ScoreText);

            SceneManager.sceneLoaded += OnSceneLoaded;

        }

        // Start is called before the first frame update
        void Start()
        {
            CardManagerInstance.PopulateDeck();
        }

        #endregion

        #region State Management

        // sloppy, but the deadline is close and this is a fast workaround

        public void ForceScene()
        {
            SceneLoader.LoadScene();
        }

        public void MainMenu()
        {
            SceneLoader.LoadMainMenu();

        }

        public void UpdateGameState(GameState newGameState)
        {
            gameState = newGameState;

            switch (newGameState)
            {
                case GameState.StartGame:
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
                    RuleManager.UpdateRuleState(RuleManager.RuleState.checkRules, gameObject.transform, gameObject);
                    SceneLoader.UpdateSceneState(SceneLoader.SceneState.nextScene);
                    break;
                case GameState.RestartGame:
                    MainMenu();
                    break;
                default:
                    break;
            }

            OnGameStateChanged?.Invoke(newGameState);
        }
        #endregion

        #region Methods

        //TODO: should be moved to scene manager, really.
        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if(scene.buildIndex == 0)
            {
                MainMenuCleanUp();
            }
            // level end screens
            if (scene.buildIndex == 2 || scene.buildIndex == 4)
            {
                SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.LevelFinished);
                BgMusic.BgInstance.GetComponent<AudioSource>().Play();
                ScoreText.GetComponent<TextMeshProUGUI>().text = "";
                CardSlots.SetActive(false);
                GameObject.Find("ScoreScreenText").GetComponentInChildren<TextMeshProUGUI>().text = "Du hast letzte Runde " + CurrentPoints + " Punkte geschafft!";
            }
            // endgame screen
            if (scene.buildIndex == 6)
            {
                SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.EndGame);
                BgMusic.BgInstance.GetComponent<AudioSource>().Play();
                ScoreText.GetComponent<TextMeshProUGUI>().text = "";
                CardSlots.SetActive(false);
                GameObject.Find("ScoreScreenText").GetComponentInChildren<TextMeshProUGUI>().text = "Du hast letzte Runde " + CurrentPoints + " Punkte geschafft!";
            }
            
            if(scene.buildIndex == 1 || scene.buildIndex == 3 || scene.buildIndex == 5)
            {
                Canvas.SetActive(true);
                CardSlots.SetActive(true);
                ScoreText.GetComponent<TextMeshProUGUI>().text = CurrentPoints.ToString();
                LevelManager.UpdateLevelState(LevelManager.LevelState.setUp);
                RuleManager.UpdateRuleState(RuleManager.RuleState.assignRules, gameObject.transform, gameObject);
            }
        }

        private void MainMenuCleanUp()
        {
            Destroy(GameManagerInstance);
            Destroy(CardManagerInstance);
            Destroy(SceneLoader);
            Destroy(LevelManager);
            Destroy(RuleManager);
            Destroy(GameObject.Find("CardSlots"));
            Destroy(GameObject.Find("CardContainer"));
            Destroy(GameObject.Find("Canvas"));
            Destroy(ScoreText);
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
            ScoreText.GetComponent<TextMeshProUGUI>().text = CurrentPoints.ToString();
            return CurrentPoints;
        }

        private void UpdateLevelNumber()
        {
            CurrentLevel++;
        }
        #endregion

    }
}

