using UnityEngine;

public class WheelMovement : MonoBehaviour
{
    private WheelCollider col;
    private Vector3 pos;
    private Quaternion rot;
    public GameObject mesh;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        col = GetComponent<WheelCollider>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        col.GetWorldPose(out pos, out rot);
        mesh.transform.position = pos;
        rot.eulerAngles = rot.eulerAngles + new Vector3(90, 0, 90);
        mesh.transform.rotation = rot;
    }
    private void Update()
    {
        
    }
}
