using System.Collections;
using UnityEditor.ShaderGraph.Internal;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.InputSystem.XInput;

public class RoverMovement : MonoBehaviour
{
    private RoverControls controls;
    public WheelCollider wheel11, wheel12, wheel13, wheel14, wheel21, wheel22, wheel23, wheel24;
    public Rigidbody roverRB;
    public float Xinput;
    public float Yinput;
    public float power = 600.0f;
    public float turnAngle = 60.0f;
    public float brakePower = 1200.0f;
    public float currentRotY;
    public float roverSpeed;
    float currentSteer;
    public float turnPower = 60.0f;
    public float originalTurn = 60.0f;
    public float decreaseInSteerBySpeed = 2.0f;
    public bool brakeInput;
    public bool resetRotation;
    public Quaternion startRot;
    public Vector3 resetOffset = new Vector3(0, 5, 0);
    public Vector3 centerOfMass = new Vector3(2.8f, 0f, -5.8f);

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
        turnAngle = originalTurn;
        roverRB.centerOfMass = centerOfMass;
    }

    // Update is called once per frame
    void Update()
    {
        if(originalTurn - ((roverSpeed / decreaseInSteerBySpeed)) > 0)
        {
            turnAngle = originalTurn - ((roverSpeed) / decreaseInSteerBySpeed);
        }
        else
        {
            turnAngle = 1.0f;
        }
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
        Acc(wheel11);
        Acc(wheel12);
        Acc(wheel13);
        Acc(wheel14);
        Acc(wheel21);
        Acc(wheel22);
        Acc(wheel23);
        Acc(wheel24);
        currentSteer = (wheel14.steerAngle + wheel24.steerAngle) / 2;
        if(Xinput > 0)
        {
            SteerRight();
        }
        else if(Xinput < 0)
        {
            SteerLeft();
        }
        else if(Xinput == 0)
        {
            SteerIdle();
        }
        if (brakeInput)
        {
            Brake(wheel11, brakePower);
            Brake(wheel12, brakePower);
            Brake(wheel13, brakePower);
            Brake(wheel14, brakePower);
            Brake(wheel21, brakePower);
            Brake(wheel22, brakePower);
            Brake(wheel23, brakePower);
            Brake(wheel24, brakePower);
        }
        else
        {
            Brake(wheel11, 0.0f);
            Brake(wheel12, 0.0f);
            Brake(wheel13, 0.0f);
            Brake(wheel14, 0.0f);
            Brake(wheel21, 0.0f);
            Brake(wheel23, 0.0f);
            Brake(wheel24, 0.0f);
        }
        if (resetRotation)
        {
            ResetRotation();
        }
    }
    void Acc(WheelCollider wheel)
    {
        wheel.motorTorque = -Yinput * power;
    }

    void SteerRight()
    {
        wheel14.steerAngle = Mathf.MoveTowards(currentSteer, turnAngle, Xinput * turnPower);
        wheel24.steerAngle = Mathf.MoveTowards(currentSteer, turnAngle, Xinput * turnPower);
        currentSteer = (wheel14.steerAngle + wheel24.steerAngle) / 2;
    }

    void SteerLeft()
    {
        wheel14.steerAngle = Mathf.MoveTowards(currentSteer, -turnAngle, Mathf.Abs(Xinput) * turnPower);
        wheel24.steerAngle = Mathf.MoveTowards(currentSteer, -turnAngle, Mathf.Abs(Xinput) * turnPower);
        currentSteer = (wheel14.steerAngle + wheel24.steerAngle) / 2;
    }

    void SteerIdle()
    {
        wheel14.steerAngle = Mathf.MoveTowards(currentSteer, 0.0f, turnPower);
        wheel24.steerAngle = Mathf.MoveTowards(currentSteer, 0.0f, turnPower);
        currentSteer = (wheel14.steerAngle + wheel24.steerAngle) / 2;
    }

    void Brake(WheelCollider wheel, float brakeStrength)
    {
        wheel.brakeTorque = brakeStrength;
    }
    void ResetRotation()
    {
        roverRB.angularVelocity = Vector3.zero;
        roverRB.linearVelocity = Vector3.zero;
        transform.position = transform.position + resetOffset;
        transform.rotation = startRot;
    }
}
