using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI;

public class Settings : MonoBehaviour
{
    public AudioMixer mixer;
    
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMasterVolume(float masterValue)
    {
        Debug.Log("changed volume to: " + masterValue);
        mixer.SetFloat("Master", Mathf.Log10(masterValue) * 20);
    }
}
