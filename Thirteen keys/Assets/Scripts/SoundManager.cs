using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager instance;

    private AudioSource soundPlayer;
    private float volume;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
        soundPlayer = GetComponent<AudioSource>();
        volume = 1f;
    }

    public void PlaySound(AudioClip clip)
    {
        soundPlayer.clip = clip;
        soundPlayer.loop = false;
        soundPlayer.time = 0;
        soundPlayer.volume = volume;
        soundPlayer.Play();
    }

    public void SetVolume(float vol)
    {
        volume = vol;
    }

}
