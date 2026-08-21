using UnityEngine;

public class RoverDustController : MonoBehaviour
{
    RoverControls control;
    public ParticleSystem[] dust;

    public GameObject[] wheels;

    public float forwardInput;
    public bool isBrake;

    RaycastHit hit;
    public float maxRaycastForWheelParticles = 2.0f;
    bool canParticle;
    bool canBrakeParticle;

    public float speedForParticles = 150.0f;

    public GameObject rover;
    public RoverMovement roverScript;

    public Rigidbody roverRB;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        roverScript = rover.GetComponent<RoverMovement>();
        control = new RoverControls();
        roverRB = rover.GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        control.Player.Move.Enable();
        control.Player.Sprint.Enable();
    }

    private void OnDisable()
    {
        control.Player.Move.Disable();
        control.Player.Sprint.Disable();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < dust.Length; i++) 
        {
            EmitParticles(dust[i], wheels[i]);
        }
    }

    void EmitParticles(ParticleSystem particle, GameObject wheel)
    {
        if(roverRB.linearVelocity.magnitude > 2)
        {
            canBrakeParticle = true;
        }
        else
        {
            canBrakeParticle = false;
        }

        if (Physics.Raycast(wheel.transform.position, Vector3.down, out hit, maxRaycastForWheelParticles))
        {
            canParticle = true;
        }
        else
        {
            canParticle = false;
        }
        forwardInput = control.Player.Move.ReadValue<Vector2>().y;
        isBrake = control.Player.Sprint.IsPressed();

        if ((forwardInput > 0 || (isBrake && canBrakeParticle) || roverScript.roverSpeed > speedForParticles) && canParticle)
        {
            particle.Play();
        }
        else if ((forwardInput <= 0 && isBrake == false) || canParticle == false || (isBrake && canBrakeParticle == false))
        {
            particle.Stop();
        }
    }
}
