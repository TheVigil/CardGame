using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using GameManager;
public class Deck : MonoBehaviour
{
   // two dummy objects to test the logic with
    public GameObject PlayerCard;
    private GameObject PlayerHandArea;
    private GameManager.GameManager GameManager = new GameManager.GameManager();

    // Start is called before the first frame update
    void Start()
    {
        PlayerHandArea = GameObject.Find("PlayerHandArea");
        
    }

    public void Draw()
    {
        /*GameObject Card = Instantiate(PlayerCard, new Vector2(0, 0), Quaternion.identity);
        Card.transform.SetParent(PlayerHandArea.transform, false);*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
