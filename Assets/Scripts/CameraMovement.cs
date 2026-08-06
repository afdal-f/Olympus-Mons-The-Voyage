using UnityEngine;
using UnityEngine.Rendering;

public class CameraMovement : MonoBehaviour
{
    private Camera mainCam;
    private RoverMovement rover;
    public LayerMask moontan;
    public float fovIncreaseStart = 40.0f;
    public float fovIncreaseLast = 140.0f;
    public Vector3 camPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCam = Camera.main;
        camPos = mainCam.transform.position;
        rover = GetComponent<RoverMovement>();
    }

    private void Update()
    {
        Debug.Log(rover.roverSpeed);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (rover.roverSpeed > fovIncreaseStart && rover.roverSpeed <= fovIncreaseLast)
        {
            mainCam.fieldOfView = rover.roverSpeed;
        }
        else if (rover.roverSpeed > fovIncreaseLast)
        {
            mainCam.fieldOfView = fovIncreaseLast;
        }
        else if (rover.roverSpeed <= fovIncreaseStart)
        {
            mainCam.fieldOfView = fovIncreaseStart;
        }
    }
}
