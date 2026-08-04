using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Camera mainCam;
    private RoverMovement rover;
    private float camReverseRate;
    public Vector3 defaultPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        defaultPos = transform.position;
        mainCam = Camera.main;
        rover = GetComponent<RoverMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rover.roverSpeed >= 30 && rover.roverSpeed <= 50 && transform.position.z <= 30)
        {
            transform.Translate(new Vector3(0, 0, 1) * camReverseRate * Time.deltaTime);
        }
        else if (rover.roverSpeed >= 50 && rover.roverSpeed <= 70 && transform.position.z <= 35)
        {
            transform.Translate(new Vector3(0, 0, 1) * camReverseRate * Time.deltaTime);
        }
        else if (rover.roverSpeed >= 70 && rover.roverSpeed <= 100 && transform.position.z <= 40)
        {
            transform.Translate(new Vector3(0, 0, 1) * camReverseRate * Time.deltaTime);
        }
        else if (rover.roverSpeed >= 100 && transform.position.z <= 45)
        {
            transform.Translate(new Vector3(0, 0, 1) * camReverseRate * Time.deltaTime);
        }
        else
        {
            transform.position = defaultPos;
        }
    }
}
