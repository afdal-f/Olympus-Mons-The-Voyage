using UnityEngine;

public class CheckPointDirectionFinder : MonoBehaviour
{
    private Vector3 pointerDirection;
    public GameObject check1;
    public GameObject check2;
    public GameObject check3;
    public GameObject finalPoint;
    public GameObject currentCheck;
    public bool gameEnd;
    public float bounds;
    public float distanceToCheck;
    Quaternion initRot;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        gameEnd = false;
        initRot = transform.rotation;
    }

    void Start()
    {
        currentCheck = check1;
    }

    // Update is called once per frame
    void Update()
    {
        distanceToCheck = (currentCheck.transform.position - transform.position).magnitude;
        if(currentCheck == check1)
        {
            Point(check1);
            CheckPos(check1, check2);
        }
        else if(currentCheck == check2)
        {
            Point(check2);
            CheckPos(check2, check3);
        }
        else if(currentCheck == check3)
        {
            Point(check3);
            CheckPos(check3, finalPoint);
        }
        else if(currentCheck == finalPoint)
        {
            Point(finalPoint);
            CheckPos(finalPoint, finalPoint);
        }
        Debug.Log("Distance to next checkpoint is :" + distanceToCheck);
    }

    void Point(GameObject check)
    {
        if (currentCheck == check)
        {
            pointerDirection = check.transform.position - transform.position;
            pointerDirection = new Vector3(pointerDirection.x, 0, pointerDirection.z);
            initRot.eulerAngles = new Vector3(0, 180, 0);
            transform.rotation = Quaternion.LookRotation(pointerDirection) * initRot;
        }
    }
    
    void CheckPos(GameObject check, GameObject newCheck)
    {
        float minX = check.transform.position.x - bounds;
        float maxX = check.transform.position.x + bounds;
        float minZ = check.transform.position.z - bounds;
        float maxZ = check.transform.position.z + bounds;
        if (transform.position.x <= maxX && transform.position.z <= maxZ && transform.position.x >= minX && transform.position.z >= minZ)
        {
            currentCheck = newCheck;
        }
        float fMinX = finalPoint.transform.position.x - bounds;
        float fMaxX = finalPoint.transform.position.x + bounds;
        float fMinZ = finalPoint.transform.position.z - bounds;
        float fMaxZ = finalPoint.transform.position.z + bounds;
        if (transform.position.x <= fMaxX && transform.position.z <= fMaxZ && transform.position.x >= fMinX && transform.position.z >= fMinZ)
        {
            Destroy(gameObject);
            Aesthetic();
        }
    }

    void Aesthetic()
    {

    }
}