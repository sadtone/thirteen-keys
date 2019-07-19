using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;

    private static float volume;

    private static AudioSource bgmPlayer;
    private static AudioSource sfxPlayer;

    public AudioClip startBGM;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            return;
        }
        DontDestroyOnLoad(this);
        bgmPlayer = GetComponent<AudioSource>();
        sfxPlayer = GetComponent<AudioSource>();
        volume = 1f;
        PlayBGM(startBGM);
    }

    public static void PlayBGM(AudioClip clip)
    {
        bgmPlayer.Stop();
        bgmPlayer.clip = clip;
        bgmPlayer.loop = true;
        bgmPlayer.time = 0;
        bgmPlayer.Play();
    }

    public static void PlaySound(AudioClip clip)
    {
        sfxPlayer.clip = clip;
        sfxPlayer.Play();
    }

    public static void SetVolume(float vol)
    {
        volume = vol;
    }

}
