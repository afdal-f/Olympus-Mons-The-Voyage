using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider masterSlider;
    public Slider vehicleSoundSlider;
    public Slider backgroundMusicSlider;
    public float masterSliderValue;
    public float vehicleSoundSliderValue;
    public float backgroundMusicSliderValue;
    
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Update is called once per frame
    void Update()
    {
        masterSliderValue = masterSlider.value;
        SetMasterVolume(masterSlider.value);
        masterSlider.value = masterSliderValue;

        vehicleSoundSliderValue = vehicleSoundSlider.value;
        SetVehicleVolume(vehicleSoundSlider.value);
        vehicleSoundSlider.value = vehicleSoundSliderValue;

        backgroundMusicSliderValue = backgroundMusicSlider.value;
        SetBackgroundMusicVolume(backgroundMusicSlider.value);
        backgroundMusicSlider.value = backgroundMusicSliderValue;
    }

    public void SetMasterVolume(float value)
    {
        mixer.SetFloat("Master", Mathf.Lerp(-60.0f, 10.0f, value));
    }
    public void SetVehicleVolume(float value)
    {
        mixer.SetFloat("VehicleSounds", Mathf.Lerp(-60.0f, 10.0f, value));
    }
    public void SetBackgroundMusicVolume(float value)
    {
        mixer.SetFloat("BackgroundMusic", Mathf.Lerp(-60.0f, 10.0f, value));
    }
}
