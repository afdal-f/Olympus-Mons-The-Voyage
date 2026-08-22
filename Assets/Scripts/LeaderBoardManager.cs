using UnityEngine;
using LootLocker.Requests;
using TMPro;

public class LeaderboardManager : MonoBehaviour
{
    public TMP_Text rankOutput;
    private const string leaderboardKey = "olympus_normal";

    private void Start()
    {
        rankOutput.gameObject.SetActive(false);
    }
    private void Update()
    {
        
    }
    public void SubmitScore(int score)
    {
        LootLockerSDKManager.SubmitScore(
            "",
            score,
            leaderboardKey,
            response =>
            {
                if (response.success)
                {
                    Debug.Log("Score submitted!");
                    Debug.Log("Rank: " + response.rank);
                    rankOutput.gameObject.SetActive(true);
                    rankOutput.text = "Rank in leaderboard: " + response.rank;
                }
                else
                {
                    Debug.LogError("Score submission failed!");
                    Debug.LogError(response.errorData);
                }
            }
        );
    }
}