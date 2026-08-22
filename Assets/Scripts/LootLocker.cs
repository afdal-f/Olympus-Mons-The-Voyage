using UnityEngine;
using LootLocker.Requests;

public class LootLockerLogin : MonoBehaviour
{
    private void Start()
    {
        StartGuestSession();
    }

    private void StartGuestSession()
    {
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (response.success)
            {
                Debug.Log("LootLocker login successful!");
                Debug.Log("Player ID: " + response.player_id);
            }
            else
            {
                Debug.LogError("LootLocker login FAILED!");
                Debug.LogError(response.errorData);
            }
        });
    }
}