using UnityEngine;

public class BrakeLights : MonoBehaviour
{
    private RoverControls controls;
    public bool brakeInput;
    public Light brakeLight;
    public float backLightIntensity = 9999.0f;
    public float lightOnSpeed = 19998.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        controls = new RoverControls();
    }

    private void OnEnable()
    {
        controls.Player.Sprint.Enable();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        brakeInput = controls.Player.Sprint.IsPressed();
        if(!brakeInput)
        {
            brakeLight.intensity = 0;
        }
        else if(brakeInput)
        {
            brakeLight.intensity = Mathf.MoveTowards(0, backLightIntensity, lightOnSpeed);
        }
    }
}
