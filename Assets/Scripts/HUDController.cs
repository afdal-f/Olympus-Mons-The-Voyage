using TMPro;
using UnityEngine;

public class HUDController : MonoBehaviour
{
    public TMP_Text speed;
    public TMP_Text distance;
    public TMP_Text checkpoint;

    public GameObject rover;
    public GameObject pointer;

    public RoverMovement roverMovement;
    public CheckPointDirectionFinder pointerScript;

    public float speedVar;
    public GameObject nextCheckpoint;
    public float DistanceToNextCheck;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        roverMovement = rover.GetComponent<RoverMovement>();
        pointerScript = pointer.GetComponent<CheckPointDirectionFinder>();
    }

    // Update is called once per frame
    void Update()
    {
        speedVar = roverMovement.roverSpeed;
        nextCheckpoint = pointerScript.currentCheck;
        DistanceToNextCheck = pointerScript.distanceToCheck;

        speed.text = "" + Mathf.Round(speedVar);
        distance.text = "Distance to the next checkpoint is: " + Mathf.Round(DistanceToNextCheck);
        checkpoint.text = "The next checkpoint is: " + nextCheckpoint.name;
    }
}
