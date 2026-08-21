using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class RoverMusic : MonoBehaviour{

    public AudioSource throttleSound;
    public AudioSource screechingSound;

    public GameObject rover;

    public RoverControls controls;

    public RoverMovement roverScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        roverScript = rover.GetComponent<RoverMovement>();
        controls = new RoverControls();
    }

    private void OnEnable()
    {
        controls.Player.Move.Enable();
        controls.Player.Sprint.Enable();
    }

    private void OnDisable()
    {
        controls.Player.Sprint.Disable();
        controls.Player.Move.Enable();
    }

    void Start()
    {
        throttleSound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = controls.Player.Move.ReadValue<Vector2>();
        bool isBrake = controls.Player.Sprint.IsPressed();
        if (input.y > 0)
        {
            throttleSound.volume = roverScript.roverSpeed / 35;
            throttleSound.pitch = roverScript.roverSpeed / 35f;
        }
        else if (input.y <= 0)
        {
            throttleSound.volume = Mathf.MoveTowards(throttleSound.volume, 0.0f ,0.8f);
            //throttleSound.pitch = Mathf.MoveTowards(throttleSound.volume, 0.5f, 0.1f);
        }
        if (isBrake && !screechingSound.isPlaying)
        {
            screechingSound.Play();
        }
        else if (!isBrake)
        {
            screechingSound.Stop();
        }
    }
}
