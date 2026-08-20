using System.Collections;
using UnityEngine;

public class DustDevilController : MonoBehaviour
{
    public ParticleSystem dustDevil;
    public GameObject rover;
    public float sBounds = 500.0f;

    public float minX, maxX, minZ, maxZ;
    public Vector3 rPos;

    public Vector3 spawnPos;
    public float ySpawn;

    private float xSpawn;
    private float zSpawn;
    private RaycastHit hit;
    public float dustDevilLifetime = 50.0f;

    public bool currentDustDevilExist;
    public float dustDevilMovementSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(dustDevilSpawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator dustDevilSpawner()
    {
        rPos = rover.transform.position;
        minX = rPos.x - sBounds;
        maxX = rPos.x + sBounds;
        minZ = rPos.z - sBounds;
        maxZ = rPos.z + sBounds;

        xSpawn = Random.Range(minX, maxX);
        zSpawn = Random.Range(minZ, maxZ);

        spawnPos = new Vector3(xSpawn, rover.transform.position.y + 1000, zSpawn);

        if(Physics.Raycast(spawnPos, Vector3.down, out hit, 10000))
        {
            ySpawn = hit.point.y;
        }

        spawnPos = new Vector3(xSpawn, ySpawn, zSpawn);

        ParticleSystem sDustDevil = Instantiate(dustDevil, spawnPos, dustDevil.transform.rotation);
        currentDustDevilExist = true;

        StartCoroutine(MoveDustDevil(sDustDevil));

        yield return new WaitForSeconds(dustDevilLifetime);

        StartCoroutine(dustDevilSpawner());

        Destroy(sDustDevil.gameObject);

    }

    IEnumerator MoveDustDevil(ParticleSystem movingDustDevil)
    {
        Vector3 direction = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));
        while (movingDustDevil != null)
        {
            movingDustDevil.transform.Translate(direction * Time.deltaTime * dustDevilMovementSpeed);

            Vector3 dustDevilPositionCorrectorRayOriginPosition = new Vector3(movingDustDevil.transform.position.x, 10000, movingDustDevil.transform.position.z);

            RaycastHit correctorHit;

            if (Physics.Raycast(dustDevilPositionCorrectorRayOriginPosition, Vector3.down, out correctorHit, 1000000))
            {
                movingDustDevil.transform.position = new Vector3(movingDustDevil.transform.position.x, correctorHit.point.y, movingDustDevil.transform.position.z);
            }
            yield return null;
        }
    }
}
