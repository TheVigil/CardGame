using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data.Objects;

public class DragAndDrop : MonoBehaviour
{
    public GameObject Canvas;
    private bool isDragging = false;
    private bool isOverDropZone = false;
    private bool isDraggable = true;
    private GameObject dropZone;
    private Vector3 origin;
    private GameObject startParent;

    private void Start()
    {
        Canvas = GameObject.Find("Canvas");
  
    }
    void Update()
    {
        if (isDragging)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            transform.SetParent(Canvas.transform, true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // cards should only collide with a drop zone so that they cannot simply be placed anywhere on the board
        isOverDropZone = true;
        dropZone = collision.gameObject;

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isOverDropZone = false;
        dropZone = null;

    }

    public void StartDrag()
    {
        //if the gameobject is draggable, store the parent and position of it so we know where to return it if it isn't put in a dropzone
        if (!isDraggable) return;
        startParent = transform.parent.gameObject;
        isDragging = true;
    }

    public void EndDrag()
    {
        if (!isDraggable) return;

        isDragging = false;

        //if the gameobject is put in a dropzone, set it as a child of the dropzone
        if (isOverDropZone)
        {
            transform.SetParent(dropZone.transform, false);
            isDraggable = false;
            dropZone.GetComponent<DropZone>().DisableDropZoneCollider();
            this.gameObject.GetComponent<Card>().played = true;
            this.gameObject.GetComponent<Card>().OnDrop();
        }
        //otherwise, send it to the hand area
        else
        {
            transform.position = this.gameObject.transform.parent.position;
            transform.SetParent(startParent.transform, false);
        }
    }
}