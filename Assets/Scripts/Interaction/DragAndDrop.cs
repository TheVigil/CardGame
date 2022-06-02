using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    /**
     * 
     * //TODO: what is the bug here? They parent correctly, but are snapped not back to the original pos, but some random pos outside the rendered canvas area. . .
     * 
     * StartDrag and EndDrag are called by the event detector component registered on the gameobject. 
     * Cards should snap back to the hand area if they are not placed in a dropzone.
     * 
     */
    public void StartDrag()
    {
        //if the gameobject is draggable, store the parent and position of it so we know where to return it if it isn't put in a dropzone
        if (!isDraggable) return;
        origin = gameObject.transform.position;
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
        }        
        //otherwise, send it to the hand area
        else
        {
            transform.position = startParent.transform.position;
            transform.SetParent(startParent.transform, false);
        }
    }
}