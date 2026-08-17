using UnityEngine;

public class RoverDustController : MonoBehaviour
{
    RoverControls control;
    public ParticleSystem[] dust;

    public float forwardInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        control = new RoverControls();
    }

    private void OnEnable()
    {
        control.Player.Move.Enable();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        forwardInput = control.Player.Move.ReadValue<Vector2>().y;

        if (forwardInput > 0)
        {
            for(int i = 0; i < dust.Length; i++)
            {
                dust[i].Play();
            }
        }
        else if (forwardInput <= 0) 
        {
            for (int j = 0; j < dust.Length; j++)
            {
                dust[j].Stop();
            }
        }
    }
}
