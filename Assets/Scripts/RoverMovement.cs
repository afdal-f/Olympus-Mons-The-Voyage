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
    public Vector3 centerOfMass = new Vector3(2.8f, 0f, -5.8f);
    float currentSteer;
    public float turnPower = 60.0f;

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
        roverRB.centerOfMass = centerOfMass;
    }

    // Update is called once per frame
    void Update()
    {
        roverSpeed = roverRB.linearVelocity.magnitude * (18 / 5);
        
        Vector2 input = controls.Player.Move.ReadValue<Vector2>();
        
        //Xinput is the turning input
        Xinput = input.x;
        
        //Yinput is the forward and backward input
        Yinput = input.y;

        //brakeInput is for the handbrake
        brakeInput = controls.Player.Sprint.IsPressed();
        resetRotation = controls.Player.Jump.IsPressed();
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
        currentSteer = (wheel14.steerAngle + wheel24.steerAngle) / 2;
        if(Xinput > 0)
        {
            wheel14.steerAngle = Mathf.MoveTowards(currentSteer, turnAngle, Xinput * turnPower);
            wheel24.steerAngle = Mathf.MoveTowards(currentSteer, turnAngle, Xinput * turnPower);
            Debug.Log("RIGHT");
            currentSteer = (wheel14.steerAngle + wheel24.steerAngle) / 2;
        }
        else if(Xinput < 0)
        {
            wheel14.steerAngle = Mathf.MoveTowards(currentSteer, -turnAngle, Mathf.Abs(Xinput) * turnPower);
            wheel24.steerAngle = Mathf.MoveTowards(currentSteer, -turnAngle, Mathf.Abs(Xinput) * turnPower);
            Debug.Log("LEFT");
            currentSteer = (wheel14.steerAngle + wheel24.steerAngle) / 2;
        }
        else if(Xinput == 0)
        {
            wheel14.steerAngle = Mathf.MoveTowards(currentSteer, 0.0f, turnPower);
            wheel24.steerAngle = Mathf.MoveTowards(currentSteer, 0.0f, turnPower);
            Debug.Log("IDLE");
            currentSteer = (wheel14.steerAngle + wheel24.steerAngle) / 2;
        }
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
            roverRB.angularVelocity = Vector3.zero;
            roverRB.linearVelocity = Vector3.zero;
            transform.position = transform.position + resetOffset;
            transform.rotation = startRot;
        }
    }
}
