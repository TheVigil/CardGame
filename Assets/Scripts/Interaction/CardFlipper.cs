using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Data.Objects;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
public class CardFlipper : MonoBehaviour, IPointerClickHandler
{
    
    public float x, y, z; // use these to set the rotate around whatever axis you'd like. I think y makes the most sense here.
    public GameObject cardBack;
    public bool cardBackActive;
    public int timer;
    private SpriteRenderer cardBackSpriteRenderer;
    private SpriteRenderer parentSpriteRenderer;

    private void Start()
    {
        cardBackActive = false;
        parentSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        cardBackSpriteRenderer = gameObject.transform.Find("CardBack").GetComponent<SpriteRenderer>();
        cardBackSpriteRenderer.drawMode = SpriteDrawMode.Sliced;
    }

    private void StartFlipCard()
    {
        StopCoroutine(CalculateFlip());
        StartCoroutine(CalculateFlip());
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Debug.Log("Click!");
            StartFlipCard();
        }
        else
        {
            Debug.Log("!Click");
            return;
        }
    }

    public void Flip()
    {
        if (cardBackActive)
        {

            cardBack.SetActive(false);
            parentSpriteRenderer.enabled = true;
            cardBackSpriteRenderer.size = new Vector2(1f, 1f);
            cardBackActive = false;
        }
        else
        {
            parentSpriteRenderer.enabled = false;
            cardBack.SetActive(true);
            cardBackSpriteRenderer.size = new Vector2(1f, 1f);
            cardBackActive = true;

        }
    }

    IEnumerator CalculateFlip()
    {
        for (int i = 0; i < 180; i++)
        {
            yield return new WaitForSeconds(0.01f);
            transform.Rotate(new Vector3(x, y, z));
            timer++;

            if(timer == 90 || timer == -90)
            {
                Flip();
            }
        }

        timer = 0;
    }
}
