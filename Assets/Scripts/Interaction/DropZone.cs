using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropZone : MonoBehaviour
{

    
    private GameObject dropZone;
    private Collider2D dropZoneCollider;
    // Start is called before the first frame update
    void Start()
    {
        dropZone = this.gameObject;
        dropZoneCollider = this.gameObject.GetComponent<Collider2D>();
    }

    public void DisableDropZoneCollider()
    {
        dropZoneCollider.enabled = false;
    }

    public void EnableDropZoneCollider()
    {
        dropZoneCollider.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
