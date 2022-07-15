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
    private SpriteRenderer _cardBackSpriteRenderer;
    private SpriteRenderer _parentSpriteRenderer;
    private string _guid;

    private void Start()
    {
        cardBackActive = false;
        _parentSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        _cardBackSpriteRenderer = gameObject.transform.Find("CardBack").GetComponent<SpriteRenderer>();
        _cardBackSpriteRenderer.drawMode = SpriteDrawMode.Sliced;
        _guid = gameObject.GetComponent<ItemCard>().Guid;
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
            StartFlipCard();
        }
    }

    private void Flip()
    {
        if (cardBackActive)
        {

            cardBack.SetActive(false);
            _parentSpriteRenderer.enabled = true;
            _cardBackSpriteRenderer.size = new Vector2(1f, 1f);
            cardBackActive = false;
        }
        else
        {
            _parentSpriteRenderer.enabled = false;
            cardBack.SetActive(true);
            _cardBackSpriteRenderer.size = new Vector2(1f, 1f);
            _cardBackSpriteRenderer.sprite = Resources.Load<Sprite>("Images/CardBacks/" + _guid);
            _cardBackSpriteRenderer.flipX = true;  
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
