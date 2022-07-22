using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;
using UnityEngine.SceneManagement;
using System;

public class SceneSwitcher : MonoBehaviour
{

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

    public void OnMouseDown()
    {
        SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.ButtonClick);
        GameManager.GameManagerInstance.ForceScene();
    }
    
    public void ReturnToMenu()
    {
        GameObject.Find("Loader").GetComponent<SceneLoader>().LoadMainMenu();
    }
}
