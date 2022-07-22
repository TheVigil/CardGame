using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;

public class MenuButton : MonoBehaviour
{

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
    }
    public void PlayOneShot()
    {
        SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.ButtonClick);
    }

    public void ExitGame()
    {
        Debug.Log("Called");
        Application.Quit();
    }
}
