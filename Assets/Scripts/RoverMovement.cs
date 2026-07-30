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

    private void Awake()
    {
        controls = new RoverControls();
    }

    private void OnEnable()
    {
        controls.Player.Move.Enable();
    }

    void Start()
    {
        Debug.Log("ur a robot yeehee lol");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = controls.Player.Move.ReadValue<Vector2>();
        
        //Xinput is the turning input
        Xinput = input.x;
        
        //Yinput is the forward and backward input
        Yinput = input.y;
    }

    private void FixedUpdate()
    {
        wheel11.motorTorque = Yinput * power;
        wheel12.motorTorque = Yinput * power;
        wheel13.motorTorque = Yinput * power;
        wheel14.motorTorque = Yinput * power;
        wheel21.motorTorque = Yinput * power;
        wheel22.motorTorque = Yinput * power;
        wheel23.motorTorque = Yinput * power;
        wheel24.motorTorque = Yinput * power;
        wheel24.steerAngle = Xinput * turnAngle;
        wheel14.steerAngle = Xinput * turnAngle;
    }
}
