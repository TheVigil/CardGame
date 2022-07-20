using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace Manager
{
    //TODO: loading splash screen?
    public class SceneLoader : MonoBehaviour
    {

        private int sceneIdx = 1;
        private SceneState sceneState;
        public static event Action<SceneState> OnSceneStateChanged;

        public enum SceneState
        {
            nextScene,
        }
        public void LoadScene()
        {
            sceneIdx++;
            StartCoroutine(LoadSceneAsync(sceneIdx));
        }

        public void LoadFirstScene()
        {
            // This is lazy, please forgive me
            StartCoroutine(LoadSceneAsync(1));
        }

        public void LoadInstructionsScene()
        {
            StartCoroutine(LoadSceneAsync(4));
        }

        IEnumerator LoadSceneAsync(int sceneIdx)
        {
            // We could build in a loading screen here. . .
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneIdx);
            asyncOperation.allowSceneActivation = false;
            float progress = 0;

            while (!asyncOperation.isDone)
            { 
               
                progress = Mathf.MoveTowards(progress, asyncOperation.progress, Time.deltaTime);

                if (progress >= 0.9f)
                {
                    asyncOperation.allowSceneActivation = true;
                }
                yield return null;
            }
        }

        #region game state changes
        public void UpdateSceneState(SceneState newSceneState)
        {
            sceneState = newSceneState;

            switch (newSceneState)
            {
                case SceneState.nextScene:
                    LoadScene();
                    break;
                default:
                    break;
            }

            OnSceneStateChanged?.Invoke(newSceneState);
        }


        #endregion
    }
}
