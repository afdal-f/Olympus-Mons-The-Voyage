using System.Collections;
using UnityEngine;
using TMPro;

public class TimeTrackerForStormChase : MonoBehaviour
{
    float time;
    public TMP_Text timeDisplay;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        time = 0.0f;
        StartCoroutine(TimeTrack());
    }

    // Update is called once per frame
    void Update()
    {
        timeDisplay.text = "Time: " + time;
    }

    IEnumerator TimeTrack()
    {
        time++;
        yield return new WaitForSeconds(1f);
        StartCoroutine(TimeTrack());
    }
}
