using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;

public class RestartGame : MonoBehaviour
{
    private SceneLoader loader;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.ButtonClick);
        GameManager.GameManagerInstance.UpdateGameState(GameManager.GameState.RestartGame);
    }
}
