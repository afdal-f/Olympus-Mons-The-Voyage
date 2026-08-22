using LootLocker.Requests;
using TMPro;
using UnityEngine;

public class RankUI : MonoBehaviour
{
    public TMP_Text rankText;

    [SerializeField] private string leaderboardKey = "olympus_global";

    public void SubmitScoreAndShowRank(int score)
    {
        LootLockerSDKManager.SubmitScore(
            "",
            score,
            leaderboardKey,
            response =>
            {
                if (response.success)
                {
                    rankText.text = "#" + response.rank;

                    Debug.Log("Score submitted!");
                    Debug.Log("Rank: " + response.rank);
                    Debug.Log("Member ID: " + response.member_id);
                }
                else
                {
                    Debug.LogError("Score submission failed: " + response.errorData);
                }
            }
        );
    }
}