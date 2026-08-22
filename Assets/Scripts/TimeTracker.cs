using System.Collections;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class TimeTracker : MonoBehaviour
{
    public float timeSpent;
    public bool gameOver;
    public int score;

    public TMP_Text timeOutput;

    public GameObject pointer;
    public CheckPointDirectionFinder pointerScript;

    public LeaderboardManager leaderboard;
    public GameObject leaderboardObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        leaderboard = leaderboardObject.GetComponent<LeaderboardManager>();
        pointerScript = pointer.GetComponent<CheckPointDirectionFinder>();
        gameOver = false;
    }

    void Start()
    {
        timeOutput.text = "";
        timeSpent = 0.0f;
        StartCoroutine(checkTime());
    }

    // Update is called once per frame
    void Update()
    {
        score =(int) Mathf.Round(timeSpent);
    }

    IEnumerator checkTime()
    {
        yield return new WaitForSeconds(0.001f);
        if(pointerScript.gameEnd == true)
        {
            leaderboard.SubmitScore(score);
            timeOutput.text = "You took: " + timeSpent + " seconds to reach Caldera! Go exploring" +
                " if you want to, maybe try driving down the steep slope... If you can do it successfully without tumbling forward that is...";
            yield return new WaitForSeconds(7.0f);
            timeOutput.text = "";
            Destroy(pointer.gameObject);
            Destroy(timeOutput.gameObject);
        }
        else
        {
            timeSpent += 0.1f;
            timeOutput.text = "";
        }
        StartCoroutine(checkTime());
    }
}
