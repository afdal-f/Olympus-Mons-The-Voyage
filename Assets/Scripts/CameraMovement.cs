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
    public float camRecoilSpeed = 9.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCam = Camera.main;
        camPos = mainCam.transform.position;
        rover = GetComponent<RoverMovement>();
    }

    private void Update()
    {
        //Debug.Log(rover.roverSpeed);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (rover.cameraRecoil > fovIncreaseStart && rover.cameraRecoil <= fovIncreaseLast)
        {
            mainCam.fieldOfView = Mathf.MoveTowards(mainCam.fieldOfView, rover.cameraRecoil, camRecoilSpeed);
        }
        else if (rover.cameraRecoil > fovIncreaseLast)
        {
            mainCam.fieldOfView = Mathf.MoveTowards(mainCam.fieldOfView, fovIncreaseLast, camRecoilSpeed);
        }
        else if (rover.cameraRecoil <= fovIncreaseStart)
        {
            mainCam.fieldOfView = Mathf.MoveTowards(mainCam.fieldOfView, fovIncreaseStart, camRecoilSpeed);
        }
    }
}
