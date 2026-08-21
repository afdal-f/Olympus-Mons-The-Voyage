using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuButtons : MonoBehaviour
{
    public EscMenu escMenu;

    public void Start()
    {
        escMenu = GetComponent<EscMenu>();
    }
    public void Quit()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void Resume()
    {
        escMenu.hudMenuOpen = false;
    }
    public void Reset()
    {
        SceneManager.LoadScene("GamePlay");
    }

}
