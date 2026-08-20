using System.Collections;
using UnityEngine;

public class DustStorm : MonoBehaviour
{
    public ParticleSystem dustStorm;
    public GameObject rover;
    public float minX, minZ, maxX, maxZ;
    public float bounds = 1000;
    public float windSpeed = 100.0f;
    public float stormLifetime = 500.0f;
    public Vector3 direction;
    public Vector3 spawnPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnStorm());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnStorm()
    {
        minZ = rover.transform.position.z - bounds;
        minX = rover.transform.position.x - bounds;
        maxZ = rover.transform.position.z + bounds;
        maxX = rover.transform.position.x + bounds;

        spawnPos = new Vector3(Random.Range(minX, maxX), rover.transform.position.y, Random.Range(minZ, maxZ));
        direction = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));
        Quaternion lookDirection = Quaternion.LookRotation(direction.normalized);

        ParticleSystem spawnedStorm = Instantiate(dustStorm, spawnPos, lookDirection);

        StartCoroutine(moveStorm(spawnedStorm, direction));

        yield return new WaitForSeconds(stormLifetime);
    
        Destroy(spawnedStorm.gameObject);

        StartCoroutine(SpawnStorm());
    }

    IEnumerator moveStorm(ParticleSystem storm, Vector3 direction)
    {
        while (storm != null)
        {
            storm.transform.Translate(direction.normalized * Time.deltaTime * windSpeed);
            Debug.Log(storm.transform.position);
            yield return null;
        }
    }
}
