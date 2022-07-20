using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;

public class DrawDeck : MonoBehaviour
{

    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.GameManagerInstance;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMouseDown()
    {
        gameManager.GetComponent<CardManager>().DrawCard();
        SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.DrawCard);
    }
}
