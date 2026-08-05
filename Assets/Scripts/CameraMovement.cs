using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Camera mainCam;
    private RoverMovement rover;
    private float camReverseRate;
    public float accelZ;
    public float defaultZ;
    public float fov;
    public float speed;
    int x;
    public LayerMask moontan;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCam = Camera.main;
        rover = GetComponent<RoverMovement>();
    }

    private void Update()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        if (Physics.Raycast(mainCam.transform.position, -Vector3.forward, 1000.0f, moontan))
        {
            transform.Translate(Vector3.forward * Time.deltaTime);
        }
        if (rover.roverSpeed > 40 && rover.roverSpeed <= 100)
        {
            mainCam.fieldOfView = rover.roverSpeed;
        }
        else if (rover.roverSpeed > 140)
        {
            mainCam.fieldOfView = 100.0f;
        }
        else if (rover.roverSpeed <= 40)
        {
            mainCam.fieldOfView = 40;
        }
    }
}
