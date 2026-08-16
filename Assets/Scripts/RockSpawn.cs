using System.Collections;
using UnityEngine;

public class RockSpawn : MonoBehaviour
{
    public GameObject[] smallRocks;
    public GameObject[] mediumRocks;
    public GameObject[] largeRocks;
    public int maxSmallRocks = 1000;
    public int maxMediumRocks = 200;
    public int maxLargeRocks = 6;
    public int spawnRadius = 500;
    public float spawnInterval = 1.5f;
    public int rocksPerFrame = 20; // how many spawn attempts happen per frame - lower = smoother fps, slower fill-in
    public float oldMaxX, oldMinX, oldMaxZ, oldMinZ;
    public float newMaxX, newMinX, newMaxZ, newMinZ;
    private Vector3 oldPos;
    public GameObject rover;
    private Vector3 spawnPos;
    public float yOffset;
    private float ySpawn;
    private Vector3 hitPointRocks;
    private GameObject rockToSpawn;
    private bool firstPass = true;

    void Start()
    {
        oldPos = rover.transform.position;
        oldMaxX = oldPos.x + spawnRadius;
        oldMaxZ = oldPos.z + spawnRadius;
        oldMinX = oldPos.x - spawnRadius;
        oldMinZ = oldPos.z - spawnRadius;

        StartCoroutine(SpawnSquaresRock());
    }

    IEnumerator SpawnSquaresRock()
    {
        while (true)
        {
            ySpawn = rover.transform.position.y + yOffset;

            newMaxX = rover.transform.position.x + spawnRadius;
            newMaxZ = rover.transform.position.z + spawnRadius;
            newMinX = rover.transform.position.x - spawnRadius;
            newMinZ = rover.transform.position.z - spawnRadius;

            yield return StartCoroutine(SpawnRockBatch(smallRocks, maxSmallRocks));
            yield return StartCoroutine(SpawnRockBatch(mediumRocks, maxMediumRocks));
            yield return StartCoroutine(SpawnRockBatch(largeRocks, maxLargeRocks));

            firstPass = false;

            oldMaxX = newMaxX;
            oldMaxZ = newMaxZ;
            oldMinX = newMinX;
            oldMinZ = newMinZ;

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    IEnumerator SpawnRockBatch(GameObject[] rockArray, int maxCount)
    {
        int spawnedThisFrame = 0;

        for (int i = 0; i < maxCount; i++)
        {
            spawnPos = new Vector3(Random.Range(newMinX, newMaxX), ySpawn, Random.Range(newMinZ, newMaxZ));

            if (Physics.Raycast(spawnPos, Vector3.down, out RaycastHit hit, 10000.0f))
            {
                hitPointRocks = hit.point;

                // on the first pass there is no "old" square yet, so fill the whole new square
                bool insideOldSquare = !firstPass
                    && hitPointRocks.x <= oldMaxX && hitPointRocks.x >= oldMinX
                    && hitPointRocks.z <= oldMaxZ && hitPointRocks.z >= oldMinZ;

                if (!insideOldSquare)
                {
                    rockToSpawn = rockArray[Random.Range(0, rockArray.Length)];
                    GameObject newRock = Instantiate(rockToSpawn, hitPointRocks, rockToSpawn.transform.rotation);

                    DestroyIfOutOfNewSquare destroyScript = newRock.GetComponent<DestroyIfOutOfNewSquare>();
                    if (destroyScript != null)
                        destroyScript.varS = this; // assign directly, skips GameObject.Find on every rock
                }
            }

            spawnedThisFrame++;
            if (spawnedThisFrame >= rocksPerFrame)
            {
                spawnedThisFrame = 0;
                yield return null; // spread work across frames instead of one big burst
            }
        }
    }
}