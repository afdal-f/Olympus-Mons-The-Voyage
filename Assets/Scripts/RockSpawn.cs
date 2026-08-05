using UnityEngine;
using UnityEngine.UIElements;

public class RockSpawn : MonoBehaviour
{
    public GameObject[] smallRocks;
    public GameObject playerR;
    Vector3 rockSpawn;
    Vector3 roverPos;
    public float rockSpawnDistance = 1000.0f;
    public float ySpawn;
    public double smallRocksNo = 1e3;
    public float playerToRockSpawnOffset = 2.0f;
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;
    public Vector3 rockToHitPointOffset = new Vector3(0, 0.25f, 0);

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        roverPos = playerR.transform.position;
        minX = roverPos.x - rockSpawnDistance;
        maxX = roverPos.x + rockSpawnDistance;
        minZ = roverPos.z - rockSpawnDistance;
        maxZ = roverPos.z + rockSpawnDistance;
    }

    void Start()
    {
        ySpawn = playerR.transform.position.y + playerToRockSpawnOffset;
        SpawnRocks();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerR.transform.position.x > maxX)
        {
            roverPos = playerR.transform.position;
            minX = roverPos.x;
            maxX = roverPos.x + rockSpawnDistance*2;
            minZ = roverPos.z - rockSpawnDistance;
            maxZ = roverPos.z + rockSpawnDistance;
            SpawnRocks();
        }
        else if(playerR.transform.position.x < minX)
        {
            roverPos = playerR.transform.position;
            minX = roverPos.x - rockSpawnDistance*2;
            maxX = roverPos.x;
            minZ = roverPos.z - rockSpawnDistance;
            maxZ = roverPos.z + rockSpawnDistance;
            SpawnRocks();
        }
        if (playerR.transform.position.z > maxZ)
        {
            roverPos = playerR.transform.position;
            minZ = roverPos.z;
            maxZ = roverPos.z + rockSpawnDistance * 2;
            minX = roverPos.x - rockSpawnDistance;
            maxX = roverPos.x + rockSpawnDistance;
            SpawnRocks();
        }
        else if (playerR.transform.position.z < minZ)
        {
            roverPos = playerR.transform.position;
            minZ = roverPos.z - rockSpawnDistance * 2;
            maxZ = roverPos.z;
            minX = roverPos.x - rockSpawnDistance;
            maxX = roverPos.x + rockSpawnDistance;
            SpawnRocks();
        }
    }
    
    void SpawnRocks()
    {
        for (int i = 0; i < smallRocksNo; i++)
        {
            roverPos = playerR.transform.position;
            int rockNo = Random.Range(0, smallRocks.Length);
            rockSpawn = new Vector3(Random.Range(minX, maxX), ySpawn, Random.Range(minZ, maxZ));
            if(Physics.Raycast(rockSpawn, Vector3.down, out RaycastHit hit, 1000.0f))
            {
                Instantiate(smallRocks[rockNo], hit.point + rockToHitPointOffset, smallRocks[rockNo].transform.rotation);
            }
        }
    }
}
