using UnityEngine;
using UnityEngine.UIElements;

public class KeepTheCameraSteady : MonoBehaviour
{
    private float startRotX = 15.0f;
    private float startRotZ = 0.0f;
        
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            transform.rotation = Quaternion.Euler(15f, transform.eulerAngles.y, 0f);
    }
}
