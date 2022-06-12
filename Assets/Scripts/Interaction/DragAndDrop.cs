using UnityEngine;
using Manager;
using Data.Objects;

public class DragAndDrop : MonoBehaviour
{
    private bool overDropZone;
    private bool isDraggable;

    private GameObject startParent;
    private GameObject dropZone;
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        isDraggable = true;
    }
    public void OnMouseDown()
    {
        startParent = transform.parent.gameObject;
        
    }
    public void OnMouseDrag()
    {
        if (isDraggable)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            gameObject.GetComponent<SpriteRenderer>().size = new Vector2(1f, 1f);
            gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Foreground";
            gameObject.GetComponent<Transform>().localScale = new Vector2(0.6f, 0.6f);
            transform.Translate(mousePosition);
        }
    }

    // TODO : Maybe animate the dropzone sprites to indicate a card can be dropped?
    #region Collision Detection
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("enter " + other.name);
        if (other.gameObject.GetComponent<BoxCollider2D>().isTrigger)
        {
            dropZone = other.gameObject;
            overDropZone = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
       // Debug.Log("exit " + other.name);
        dropZone = null;
        overDropZone = false;

    }
    #endregion

    public void EndDrag()
    {
        Debug.Log("End Drag");
        if (overDropZone)
        {
            Debug.Log("over dropzone");
            transform.SetParent(dropZone.transform, false);
            transform.position = transform.parent.position;

            gameObject.GetComponent<Transform>().localScale = new Vector2(1f, 1f);
            gameObject.GetComponent<SpriteRenderer>().size = new Vector2(1f, 1f);
            gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
            gameManager.GetComponent<CardManager>().EnableCardSlot((gameObject.GetComponent<Card>().handSlotIndex));
            dropZone.GetComponent<DropZone>().DisableDropZoneCollider();

            isDraggable = false;
        }
        else
        {
            Debug.Log("Not over Drop zone");
            gameObject.GetComponent<Transform>().localScale = new Vector2(1f, 1f);
            transform.position = startParent.transform.position;
            transform.SetParent(startParent.transform, false);
            isDraggable = true;
        }
    }

}