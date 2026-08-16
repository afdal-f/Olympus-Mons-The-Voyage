using UnityEngine;

public class DestroyIfOutOfNewSquare : MonoBehaviour
{
    public RockSpawn varS;
    public float newMinX, newMinZ, newMaxX, newMaxZ;

    void Start()
    {
        // fallback for rocks placed manually in the scene rather than spawned by RockSpawn
        if (varS == null)
        {
            GameObject spawner = GameObject.Find("Spawner");
            if (spawner != null)
                varS = spawner.GetComponent<RockSpawn>();
        }
    }

    void Update()
    {
        if (varS == null) return;

        newMinX = varS.newMinX;
        newMinZ = varS.newMinZ;
        newMaxX = varS.newMaxX;
        newMaxZ = varS.newMaxZ;

        DestroyIfOutOfBounds();
    }

    void DestroyIfOutOfBounds()
    {
        if (transform.position.x > newMaxX || transform.position.x < newMinX
            || transform.position.z > newMaxZ || transform.position.z < newMinZ)
        {
            Destroy(gameObject);
        }
    }
}