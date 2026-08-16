using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditSceneManagerScript : MonoBehaviour
{
    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
