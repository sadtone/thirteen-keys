using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;

    private AudioSource audioPlayer;
    private float volume;

    public AudioClip startBGM;

    private void Start()
    {
        instance = this;
        DontDestroyOnLoad(this);
        audioPlayer = GetComponent<AudioSource>();
        volume = 1f;
        PlayBGM(startBGM);
    }

    public void PlayBGM(AudioClip clip)
    {
        audioPlayer.Stop();
        audioPlayer.clip = clip;
        audioPlayer.loop = true;
        audioPlayer.time = 0;
        audioPlayer.volume = volume;
        audioPlayer.Play();
    }

    public void SetVolume(float vol)
    {
        volume = vol;
    }

}
