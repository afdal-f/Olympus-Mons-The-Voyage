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
        StormMove();
        SetCorners();
        SetRotation();
        RaycastForY();
    }

    void SetRotation()
    {
        moveDirection = rover.transform.position - transform.position;
        lookDirection = Quaternion.LookRotation(moveDirection.normalized);
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
        Vector3 raycastInit = new Vector3(transform.position.x, transform.position.y + 1000, transform.position.z);
        if (Physics.Raycast(raycastInit, Vector3.down, out hit, 10000.0f))
        {
            transform.position = new Vector3(transform.position.x, hit.point.y, transform.position.z);
        }
    }
    private void StormMove()
    {
        transform.Translate(moveDirection.normalized * windSpeed * Time.deltaTime);
    }

}
