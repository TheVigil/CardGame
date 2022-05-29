using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 20;
    Vector3 dragOrigin;
    Vector3 difference;

    [SerializeField]
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void PanCamera()
    {
        if (Input.GetButton("PanNorth"))
        {
            dragOrigin = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetButton("PanNorth"))
        {
            // adjust camera movement, pegged to framerate
            difference = dragOrigin - mainCamera.ScreenToWorldPoint(transform.position);

            mainCamera.transform.position += difference * Time.deltaTime;

        }
    }

    // Update is called once per frame
    void Update()
    {
        PanCamera();
    }
}
