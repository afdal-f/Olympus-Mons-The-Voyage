using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PointerDirection : MonoBehaviour
{
    public GameObject goal;
    Vector3 goalPos;
    Vector3 pointingDirectionVector;
    Quaternion pointingDirection;
    float startX;
    float startZ;
    Quaternion rot;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startZ = transform.rotation.z;
        startX= transform.rotation.x;
    }

    // Update is called once per frame

    private void Update()
    {
        rot.eulerAngles = new Vector3(startX, transform.rotation.y, startZ);
        transform.rotation = rot;
    }
    void LateUpdate()
    {
        goalPos = goal.transform.position;
        pointingDirectionVector = transform.position - goalPos;
        pointingDirection.eulerAngles = pointingDirectionVector;
        transform.rotation = pointingDirection;
    }
}
