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

    private static CharacterManager CharacterManagerInstance;
    private static SceneLoader SceneLoader;
    private static LevelManager LevelManager;
    public GameState gameState;
    public static event Action<GameState> OnGameStateChanged;

    // TODO: implement the individual bits of state for the manager. What states do we need here?
    public enum GameState
    {
      StartGame,
      PlayerTurn,
      ScoreCalc,
      TurnEnd,
      LevelEnd,
    }
    #endregion

    #region setup
    private void Awake()
    {

      if (GameManagerInstance != null)
      {
        Destroy(this);
      }
      else
      {
        CharacterManagerInstance = GetComponent<CharacterManager>();
        CardManagerInstance = GetComponent<CardManager>();
        LevelManager = GetComponent<LevelManager>();
        SceneLoader = GetComponent<SceneLoader>();
        GameManagerInstance = this;
      }

      // Register persistent game objects
      UnityEngine.Object[] objects = {
        GameManagerInstance,
        CardManagerInstance,
        LevelManager,
        SceneLoader,
        GameObject.Find("CardSlots"),
        GameObject.Find("CardContainer"),
        GameObject.Find("Canvas"),
      };
      RegisterPersistentObjects(objects);
    }

    private void RegisterPersistentObjects(UnityEngine.Object[] objects)
    {
      foreach (var obj in objects)
      {
        DontDestroyOnLoad(obj);
      }
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

    #region game state changes

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
          break;
        case GameState.PlayerTurn:
          break;
        case GameState.ScoreCalc:
          break;
        case GameState.TurnEnd:
          break;
        case GameState.LevelEnd:
          SceneLoader.UpdateSceneState(SceneLoader.SceneState.nextScene);
          LevelManager.UpdateLevelState(LevelManager.LevelState.setUp);
          break;
        default:
          break;
      }

      OnGameStateChanged?.Invoke(newGameState);
    }
    #endregion


  }
}

