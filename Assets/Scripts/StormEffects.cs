using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StormEffects : MonoBehaviour
{
    public TMP_Text stormWarning;
    ParticleSystem storm;
    public Vector3 stormPos;
    public Vector3 roverPos;
    public const float bounds = 1500;
    public float minX, maxX, minZ, maxZ;
    public GameObject rover;
    public Rigidbody roverRB;
    public DustStorm stormScript;
    public Image dustOverlay;
    public GameObject marsPhenomena;
    public float dirtSwipeSpeed = 0.5f;
    public float windPowerMultiplier = 1000.0f;
    public bool smolForceForWind;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        smolForceForWind = false;
        roverRB = rover.GetComponent<Rigidbody>();
        stormScript = marsPhenomena.GetComponent<DustStorm>();
    }

    // Update is called once per frame
    void Update()
    {
        storm = stormScript.spawnedStorm;
        stormPos = storm.transform.position;
        roverPos = rover.transform.position;
        minX = stormPos.x - bounds;
        maxX = stormPos.x + bounds;
        minZ = stormPos.z - bounds;
        maxZ = stormPos.z + bounds;
        Debug.Log("minX: " + minX + " | maxX: " + maxX + " | minZ: " + minZ + " | maxZ: " + maxZ);
        if ((roverPos.x > minX) && (roverPos.z > minZ) && (roverPos.x < maxX) && (roverPos.z < maxZ))
        {
            stormWarning.text = "WARNING: YOU ARE IN A STORM!";
            smolForceForWind = true;
            dustOverlay.color = new Color(dustOverlay.color.r, dustOverlay.color.g, dustOverlay.color.b, Mathf.MoveTowards(dustOverlay.color.a, 0.7f, dirtSwipeSpeed));
        }
        else
        {
            stormWarning.text = "";
            smolForceForWind = false;
            dustOverlay.color = new Color(dustOverlay.color.r, dustOverlay.color.g, dustOverlay.color.b, Mathf.MoveTowards(dustOverlay.color.a, 0.0f, dirtSwipeSpeed));
        }
    }

    private void FixedUpdate()
    {
        if (smolForceForWind)
        {
            roverRB.AddForce(stormScript.direction * windPowerMultiplier * stormScript.windSpeed, ForceMode.Force);
        }
    }
}
