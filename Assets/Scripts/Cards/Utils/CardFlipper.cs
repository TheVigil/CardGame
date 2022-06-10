using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Data.Objects;
public class CardFlipper : MonoBehaviour
{
    /*private SpriteRenderer spriteRenderer;
    private Image image;
    private Card card;
    private GameObject canvas;
    public AnimationCurve scaleCurve;
    public float duration = 0.5f;

    private void Awake()
    {
        var parent = (gameObject.transform as RectTransform);
        canvas = GameObject.Find("Canvas");
        card = gameObject.GetComponent<Card>();
        // image = gameObject.GetComponent <Image>();
        // image.sprite = Resources.Load<Sprite>("CardFaces/cardBack");
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.drawMode = SpriteDrawMode.Sliced;
        spriteRenderer.sprite = Resources.Load<Sprite>("CardFaces/cardBack");
        spriteRenderer.size += parent.rect.size / 3.22f; // we all love magic numbers, right?

    }

    public void FlipCard()
    {
        StopCoroutine(Flip());
        StartCoroutine(Flip());
    }

    IEnumerator Flip()
    {
        

        spriteRenderer.sprite = Resources.Load<Sprite>("CardFaces/cardBack");
        // image.sprite = Resources.Load<Sprite>("CardFaces/cardBack");
        
        float time = 0f;

        while(time <= 1f) 
        { 
            float scale = scaleCurve.Evaluate(time);
            time += Time.deltaTime / duration;

            Vector3 localScale = transform.localScale;
            localScale.x = scale;
            transform.localScale = localScale;

            if(time >= 0.5)
            {
                spriteRenderer.sprite = Resources.Load<Sprite>("CardFaces/cardFront");
              // image.sprite = Resources.Load<Sprite>("CardFaces/cardFront");
            }

            yield return new WaitForFixedUpdate();
        }


        /* if(cardIndex == -1)
        {
            card.ToggleFace(false);

        }
        else
        {
            card.cardIndex = cardIndex;
            card.ToggleFace(true);
        }

        card.ToggleFace(true);
        
    }*/
}
