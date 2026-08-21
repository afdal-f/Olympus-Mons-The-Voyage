using UnityEngine;
using UnityEngine.InputSystem;

public class EscMenu : MonoBehaviour
{
    public RoverControls controls;
    public GameObject hudMenu;
    public bool hudMenuOpen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        controls = new RoverControls();
    }

    private void OnEnable()
    {
        controls.Player.Interact.Enable();
        controls.Player.Crouch.Enable();
    }
    private void OnDisable()
    {
        controls.Player.Interact.Disable();
        controls.Player.Crouch.Disable();
    }

    void Start()
    {
        hudMenuOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        hudMenu.SetActive(hudMenuOpen);
        if (controls.Player.Interact.IsPressed())
        {
            hudMenuOpen = true;
        }
        else if (controls.Player.Crouch.IsPressed())
        {
            hudMenuOpen = false;
        }
    }
}
