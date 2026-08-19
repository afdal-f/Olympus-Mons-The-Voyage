using GLTFast.Schema;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioSource music;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        music.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
