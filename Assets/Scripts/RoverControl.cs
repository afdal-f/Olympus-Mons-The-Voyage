using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UIElements;
using System;
using System.Collections;

public class RoverControl : MonoBehaviour
{
    private Rigidbody roverRB;
    private RoverControls controls;
    public float power = 20.0f;
    public float turnPower = 100.0f;
    public float speedMeasureRate = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {      
        roverRB = GetComponent<Rigidbody>();
        controls = new RoverControls();
    }
    private void Start()
    {
        for(int i = 1; i > 1; i++)
        {
            StartCoroutine(measureSpeed());
            measureSpeed();
        }
    }

    private void OnEnable()
    {
        controls.Player.Enable();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector2 moveInput = controls.Player.Move.ReadValue<Vector2>();
        roverRB.AddForce(transform.forward * power * moveInput.y, ForceMode.Force);
        transform.Rotate(transform.up * turnPower * Time.deltaTime * moveInput.x);
    }
    float InitialZ()
    {
        Vector3 distance = transform.position;
        float distanceZ = distance.z;
        return distanceZ;
    }
    float InitialX()
    {
        Vector3 distance = transform.position;
        float distanceX = distance.x;
        return distanceX;
    }
    float FinalZ()
    {
        Vector3 distance = transform.position;
        float distanceX = distance.x;
        return distanceX;
    }
    float FinalX()
    {
        Vector3 distance = transform.position;
        float distanceX = distance.x;
        return distanceX;
    }
    double distanceCovered(float fx, float fz, float ix, float iz)
    {
        double distanceX = fx - ix;
        double distanceY = fz - iz;
        double distance = Math.Pow(Math.Pow(distanceX + distanceY, 2), 0.5);
        return distance;
    }
    IEnumerator measureSpeed()
    {
        float ix = InitialX();
        float iz = InitialZ();
        yield return new WaitForSeconds(speedMeasureRate);
        Debug.Log("Speed is: " + distanceCovered(FinalX(), FinalZ(), ix, iz) / speedMeasureRate);
    }
}
