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
        gameManager = GameObject.FindObjectOfType<Manager.GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMouseDown()
    {
        Debug.Log("Draw");
        gameManager.GetComponent<CardManager>().DrawCard();
    }
}
