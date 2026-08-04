using UnityEngine;
using UnityEngine.UIElements;

public class RockSpawn : MonoBehaviour
{
    public GameObject[] bigRocks;
    public GameObject[] mediumRocks;
    public GameObject[] smallRocks;
    public GameObject playerR;
    Vector3 rockSpawn;
    Vector3 roverPos;
    float rockSpawnDistance = 1000.0f;
    public float ySpawn;
    public double smallRocksNo = 1e3;
    public double mediumRocksNo = 1e2;
    public double bigRocksNo = 1e1;
    public float playerToRockSpawnOffset = 2.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ySpawn = playerR.transform.position.y + playerToRockSpawnOffset;
        SpawnRocks();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void SpawnRocks()
    {
        for (int i = 0; i < 1e1; i++)
        {
            roverPos = playerR.transform.position;
            float minX = roverPos.x - rockSpawnDistance;
            float maxX = roverPos.x + rockSpawnDistance;
            float minZ = roverPos.z - rockSpawnDistance;
            float maxZ = roverPos.z + rockSpawnDistance;
            int rockNo = Random.Range(0, bigRocks.Length);
            rockSpawn = new Vector3(Random.Range(minX, maxX), ySpawn, Random.Range(minZ, maxZ));
            Instantiate(bigRocks[rockNo], rockSpawn, bigRocks[rockNo].transform.rotation);
        }
        for (int i = 0; i < 1e2; i++)
        {
            roverPos = playerR.transform.position;
            float minX = roverPos.x - rockSpawnDistance;
            float maxX = roverPos.x + rockSpawnDistance;
            float minZ = roverPos.z - rockSpawnDistance;
            float maxZ = roverPos.z + rockSpawnDistance;
            int rockNo = Random.Range(0, mediumRocks.Length);
            rockSpawn = new Vector3(Random.Range(minX, maxX), ySpawn, Random.Range(minZ, maxZ));
            Instantiate(mediumRocks[rockNo], rockSpawn, mediumRocks[rockNo].transform.rotation);
        }
        for (int i = 0; i < 1e3; i++)
        {
            roverPos = playerR.transform.position;
            float minX = roverPos.x - rockSpawnDistance;
            float maxX = roverPos.x + rockSpawnDistance;
            float minZ = roverPos.z - rockSpawnDistance;
            float maxZ = roverPos.z + rockSpawnDistance;
            int rockNo = Random.Range(0, smallRocks.Length);
            rockSpawn = new Vector3(Random.Range(minX, maxX), ySpawn, Random.Range(minZ, maxZ));
            Instantiate(smallRocks[rockNo], rockSpawn, smallRocks[rockNo].transform.rotation);
        }
    }
}
