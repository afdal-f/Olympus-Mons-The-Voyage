using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.XInput;

public class RoverMovement : MonoBehaviour
{
    private RoverControls controls;
    public WheelCollider wheel11, wheel12, wheel13, wheel14, wheel21, wheel22, wheel23, wheel24;
    private Rigidbody roverRB;
    public float Xinput;
    public float Yinput;
    public float motorPower = 600.0f;
    public float cameraRecoil;
    private float power;
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
    public float minSteerAngle = 3.0f;
    public float speedMax = 140.0f;
    public float speedLimitStrength = 3.0f;
    public float acceleration;
    public float accelerationToRecoilNormalizer = 6.0f;
    private float avgAcceleration;

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
        FigureAcceleration();
    }

    // Update is called once per frame
    void Update()
    {
        LimitSpeed(speedMax);
        if(originalTurn - ((roverSpeed / decreaseInSteerBySpeed)) > minSteerAngle)
        {
            turnAngle = originalTurn - ((roverSpeed) / decreaseInSteerBySpeed);
        }
        else
        {
            turnAngle = minSteerAngle;
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
        cameraRecoil = roverSpeed/2;
        Gears();
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
            Brake(wheel22, 0.0f);
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
        if (roverSpeed < speedMax)
        {
            wheel.motorTorque = -Yinput * power;
            //Debug.Log("motor torque: " + Mathf.Abs(wheel.motorTorque) + " | speed above 140 |" 
                //+ " speed is: " + roverSpeed + " | brake torque is: " + wheel.brakeTorque + " | at acceleration: " + acceleration);
        }
        else if (roverSpeed >= speedMax)
        {
            wheel.motorTorque = 0.0f;
            //Debug.Log("motor torque: " + Mathf.Abs(wheel.motorTorque) + " | speed above 140 |" 
                //+ " speed is: " + roverSpeed + " | brake torque is: " + wheel.brakeTorque  + " | at acceleration: " + acceleration);
        }
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
        roverRB.linearVelocity = Vector3.zero;
        roverRB.angularVelocity = Vector3.zero;
        transform.position = transform.position + resetOffset;
        transform.rotation = startRot;
    }
    void LimitSpeed(float maxSpeed)
    {
        if (roverSpeed >= maxSpeed)
        {
            wheel11.motorTorque = 0;
            wheel12.motorTorque = 0;
            wheel13.motorTorque = 0;
            wheel14.motorTorque = 0;
            wheel21.motorTorque = 0;
            wheel22.motorTorque = 0;
            wheel23.motorTorque = 0;
            wheel24.motorTorque = 0;
        }
    }
    
    void Gears()
    {
        if (roverSpeed < 40 && roverSpeed >= 0)
        {
            power = motorPower * 4;
        }
        if (roverSpeed < 90 && roverSpeed >= 40)
        {
            power = motorPower * 3;
        }
        if (roverSpeed < 150 && roverSpeed >= 90)
        {
            power = motorPower * 2;
        }
        if (roverSpeed < 210 && roverSpeed >= 150)
        {
            power = motorPower * 1;
        }
        if (roverSpeed < 250 && roverSpeed >= 210)
        {
            power = motorPower * 0.5f;
        }
    }
    IEnumerator Acceleration()
    {
        float velocity1 = roverSpeed;
        yield return new WaitForSeconds(0.1f);
        float velocity2 = roverSpeed;
        float accelerationM = (velocity2 - velocity1) * 10;
        acceleration = accelerationM;
        FigureAcceleration();
    }

    IEnumerator AvgAccel(float accel)
    {
        float accel1 = accel;
        yield return new WaitForSeconds(0.3f);
        float accel2 = accel;
        avgAcceleration = (accel1 + accel2) / 2;
    }

    void FigureAcceleration()
    {
        StartCoroutine(Acceleration());
        //StartCoroutine(AvgAccel(acceleration));
        //Debug.Log(avgAcceleration);
        
    }
}