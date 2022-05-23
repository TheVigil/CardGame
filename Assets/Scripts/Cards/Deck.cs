using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
   // two dummy objects to test the logic with
    public GameObject Card1;

    private GameObject Hand;
    private GameObject ActiveCardArea;

    // Start is called before the first frame update
    void Start()
    {
        Hand = GameObject.Find("Hand");
        ActiveCardArea = GameObject.Find("ActiveCardArea");
    }

    public void Draw()
    {
        GameObject Card = Instantiate(Card1, new Vector2(0, 0), Quaternion.identity);
        Card.transform.SetParent(ActiveCardArea.transform, false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
