using System.Collections;
using System.Xml.Serialization;
using UnityEngine;

public class DustStormForStormChase: MonoBehaviour
{
    public float bounds = 3000.0f;
    public GameObject rover;
    public Vector3 moveDirection;
    public Quaternion lookDirection;
    public float minX, minZ, maxX, maxZ;
    public RaycastHit hit;
    public float windSpeed;

    private void Start()
    {
        rover = GameObject.FindWithTag("Rover");
    }
    private void Update()
    {
        SetCorners();
        SetRotation();
        RaycastForY();
        StormMove();
    }

    void SetRotation()
    {
        moveDirection = rover.transform.position - transform.position;
        moveDirection = new Vector3 (moveDirection.x, transform.position.y, moveDirection.z);
        lookDirection.x = 0;
        lookDirection.z = 0;
        lookDirection.y = 0;
        transform.rotation = lookDirection;
    }

    void SetCorners()
    {
        minX = rover.transform.position.x - bounds;
        maxX = rover.transform.position.x + bounds;
        minZ = rover.transform.position.z - bounds;
        maxZ = rover.transform.position.z + bounds;
    }

    void RaycastForY()
    {
        Vector3 raycastInit = new Vector3(transform.position.x, transform.position.y + 10000, transform.position.z);
        if (Physics.Raycast(raycastInit, Vector3.down, out hit, 60000.0f))
        {
            transform.position = new Vector3(transform.position.x, hit.point.y, transform.position.z);
        }
    }
    private void StormMove()
    {
        transform.Translate(moveDirection.normalized * windSpeed * Time.deltaTime, Space.World);
    }

}
