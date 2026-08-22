using UnityEngine;
using UnityEngine.SceneManagement;

public class StormEffectsForStormChase : MonoBehaviour
{
    public GameObject rover;
    public float minX, maxX, minZ, maxZ;
    public float bounds = 1500;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rover = GameObject.FindWithTag("Rover");
        //sddad
    }

    // Update is called once per frame
    void Update()
    {
        CalculateSquareCorners();
        RoverPosCheck();
    }
    
    void CalculateSquareCorners()
    {
        minX = transform.position.x - bounds;
        maxX = transform.position.x + bounds;
        minZ = transform.position.z - bounds;
        maxZ = transform.position.z + bounds;
    }

    void RoverPosCheck()
    {
        if (rover.transform.position.x > minX && rover.transform.position.x < maxX && rover.transform.position.z > minZ && rover.transform.position.z < maxZ)
        {
            Debug.Log("YOU ARE IN THE STORM");
            SceneManager.LoadScene("YouLost");
        }
    }
}
