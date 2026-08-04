using System.Collections;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.InputSystem.XInput;

public class RoverMovement : MonoBehaviour
{
    private RoverControls controls;
    public float Xinput;
    public float Yinput;
    public WheelCollider wheel11, wheel12, wheel13, wheel14, wheel21, wheel22, wheel23, wheel24;
    public float power = 600.0f;
    public float turnAngle = 60.0f;
    public GameObject wheel11m, wheel12m, wheel13m, wheel14m, wheel21m, wheel22m, wheel23m, wheel24m;
    public float brakePower = 1200.0f;
    public bool brakeInput;
    public bool resetRotation;
    public Quaternion startRot;
    public Vector3 resetOffset = new Vector3(0, 5, 0);
    public float currentRotY;
    public Rigidbody roverRB;
    public Vector3 cameraDefaultPos;
    public float roverSpeed;
    public float acceleration;

    private void Awake()
    {
        roverRB = GetComponent<Rigidbody>();
        controls = new RoverControls();
        startRot.eulerAngles = new Vector3(transform.rotation.x, currentRotY, transform.rotation.z);
    }

    private void OnEnable()
    {
        controls.Player.Move.Enable();
        controls.Player.Sprint.Enable();
        controls.Player.Jump.Enable();
    }

    void Start()
    {
        Debug.Log("ur a robot yeehee lol");
        acceleration = roverRB.GetAccumulatedForce().magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        roverSpeed = roverRB.linearVelocity.magnitude * (18 / 5);
        Debug.Log(roverSpeed);
        Vector2 input = controls.Player.Move.ReadValue<Vector2>();
        
        //Xinput is the turning input
        Xinput = input.x;
        
        //Yinput is the forward and backward input
        Yinput = input.y;

        //brakeInput is for the handbrake
        brakeInput = controls.Player.Sprint.IsPressed();
        resetRotation = controls.Player.Jump.IsPressed();

        ChangePositionOfWheels(wheel11m, wheel11);
        ChangePositionOfWheels(wheel12m, wheel12);
        ChangePositionOfWheels(wheel13m, wheel13);
        ChangePositionOfWheels(wheel14m, wheel14);
        ChangePositionOfWheels(wheel21m, wheel21);
        ChangePositionOfWheels(wheel22m, wheel22);
        ChangePositionOfWheels(wheel23m, wheel23);
        ChangePositionOfWheels(wheel24m, wheel24);
    }

    private void FixedUpdate()
    {
        wheel11.motorTorque = -Yinput * power;
        wheel12.motorTorque = -Yinput * power;
        wheel13.motorTorque = -Yinput * power;
        wheel14.motorTorque = -Yinput * power;
        wheel21.motorTorque = -Yinput * power;
        wheel22.motorTorque = -Yinput * power;
        wheel23.motorTorque = -Yinput * power;
        wheel24.motorTorque = -Yinput * power;
        wheel14.steerAngle = turnAngle * Xinput;
        wheel24.steerAngle = turnAngle * Xinput;
        if (brakeInput)
        {
            wheel11.brakeTorque = brakePower;
            wheel12.brakeTorque = brakePower;
            wheel13.brakeTorque = brakePower;
            wheel14.brakeTorque = brakePower;
            wheel21.brakeTorque = brakePower;
            wheel22.brakeTorque = brakePower;
            wheel23.brakeTorque = brakePower;
            wheel24.brakeTorque = brakePower;
        }
        else
        {
            wheel11.brakeTorque = 0;
            wheel12.brakeTorque = 0;
            wheel13.brakeTorque = 0;
            wheel14.brakeTorque = 0;
            wheel21.brakeTorque = 0;
            wheel22.brakeTorque = 0;
            wheel23.brakeTorque = 0;
            wheel24.brakeTorque = 0;
        }
        if (resetRotation)
        {
            transform.position = transform.position + resetOffset;
            transform.rotation = startRot;
        }
    }
    void ChangePositionOfWheels(GameObject obj, WheelCollider col)
    {
        obj.transform.position = col.transform.position;
    }
}
