using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class DustStormSpawnForStormChase : MonoBehaviour
{
    public DustStormForStormChase dustStormPositioningScript;
    public ParticleSystem dustStorm;
    public ParticleSystem spawnedDustStorm;
    public GameObject rover;
    public float bounds = 5000.0f;
    public float minX, maxX, minZ, maxZ;
    public float stormLifetime = 100.0f;
    public Vector3 spawnPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rover = GameObject.FindWithTag("Rover");
        StartCoroutine(SpawnStorm());
    }

    // Update is called once per frame
    void Update()
    {
        minX = rover.transform.position.x - bounds;
        maxX = rover.transform.position.x + bounds;
        minZ = rover.transform.position.z - bounds;
        maxZ = rover.transform.position.z + bounds;
        float x = Random.Range(minX, maxX);
        float z = Random.Range(minZ, maxZ);
        spawnPos = new Vector3(x, 0, z);
    }

    IEnumerator SpawnStorm()
    {
        spawnedDustStorm = Instantiate(dustStorm, spawnPos, dustStorm.transform.rotation);
        yield return new WaitForSeconds(stormLifetime);
        StartCoroutine(SpawnStorm());
    }
}
