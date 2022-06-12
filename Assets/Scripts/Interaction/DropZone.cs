using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;

public class DropZone : MonoBehaviour
{

    
    private GameObject dropZone;
    private Collider2D dropZoneCollider;
    private GameManager gameManager;
    private LevelManager levelManager;
    // Start is called before the first frame update
    void Start()
    {
        dropZone = gameObject;
        dropZoneCollider = gameObject.GetComponent<Collider2D>();
        gameManager = GameManager.GameManagerInstance;
        levelManager = gameManager.GetComponent<LevelManager>();
    }

    private void Update()
    {

    }

    public void DisableDropZoneCollider()
    {
        dropZoneCollider.enabled = false;
        levelManager.UpdateLevelState(LevelManager.LevelState.decreaseDrops);

    }

    public void EnableDropZoneCollider()
    {
        dropZoneCollider.enabled = true;
        levelManager.UpdateLevelState(LevelManager.LevelState.increaseDrops);
    }


}
