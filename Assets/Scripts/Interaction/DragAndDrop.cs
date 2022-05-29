using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    //Canvas is assigned locally at runtime in Start(), whereas the rest are assigned contextually as this gameobject is dragged and dropped
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
        //check every frame to see if this gameobject is being dragged. If it is, make it follow the mouse and set it as a child of the Canvas to render above everything else
        if (isDragging)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            transform.SetParent(Canvas.transform, true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //in our scene, if this gameobject collides with something, it must be the dropzone, as specified in the layer collision matrix (cards are part of the "Cards" layer and the dropzone is part of the "DropZone" layer)
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
     * //TODO: what is the bug here? They parent correctly, but appear behind the ui layer (and don't always appear at the proper coordinates, it seems). . .
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
            transform.position = origin;
            transform.SetParent(startParent.transform, false);
            Debug.Log(origin);
            Debug.Log("Bad drag, set to start: ", transform.parent);
            Debug.Log("Bad drag, revert to old pos: ");
            Debug.Log(transform.position);
        }
    }
}