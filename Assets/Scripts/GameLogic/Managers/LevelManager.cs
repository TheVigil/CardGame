using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;
using System;

namespace Manager
{
    public class LevelManager : MonoBehaviour
    {

        private int level = 0;
        private int dropZones;
        private LevelState levelState;
        public static event Action<LevelState> OnLevelStateChanged;


        public enum LevelState
        {
            setUp,
            decreaseDrops,
            increaseDrops,
            checkLevelEnd,

        }

        private void Awake()
        {

        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void SetUpLevel()
        {
            level++;

            if(level == 1)
            {
                Debug.Log("Lvl1");
                dropZones = 13;
            }
            if(level == 2)
            {
                Debug.Log("Lvl2");
                dropZones = 10;
            }
            if(level == 3)
            {
                Debug.Log("Lvl3");
                dropZones = 7;
            }

            GameManager.GameManagerInstance.UpdateGameState(GameManager.GameState.UpdateLevelNumber);

        }

        private void CheckLevelEnd()
        {
            if(dropZones == 0)
            {
                GameManager.GameManagerInstance.UpdateGameState(GameManager.GameState.LevelEnd);
            }
        }

        #region level changes
        public void UpdateLevelState(LevelState newLevelState)
        {
            levelState = newLevelState;

            switch (newLevelState)
            {
                case LevelState.setUp:
                    SetUpLevel();
                    break;
                case LevelState.decreaseDrops:
                    dropZones--;
                    CheckLevelEnd();
                    break;
                case LevelState.increaseDrops:
                    dropZones++;
                    break;
                case LevelState.checkLevelEnd:
                    break;
                default:
                    break;
            }

            OnLevelStateChanged?.Invoke(newLevelState);
        }

        public int CurrentLevel
        {
            get { return level; }
        }
        #endregion
    }
}
