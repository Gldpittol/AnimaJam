using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] private AudioSource audSource;
    [SerializeField] private AudioSource musicSource;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            audSource = GetComponent<AudioSource>();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateMusicAndAudio();
    }

    public void PlayClip(AudioClip audClip)
    {
        audSource.PlayOneShot(audClip);
    }

    public void PlayMusic(AudioClip musicClip)
    {
        musicSource.clip = musicClip;
        musicSource.Play();
        musicSource.loop = true;
    }

    public void UpdateMusicAndAudio()
    {
        if (PlayerPrefs.HasKey("Audio"))
        {
            if (PlayerPrefs.GetInt("Audio") == 1)
            {
                audSource.volume = 0.2f;
            }
            else
            {
                audSource.volume = 0;
            }
        }
        
        if (PlayerPrefs.HasKey("Music"))
        {
            if (PlayerPrefs.GetInt("Music") == 1)
            {
                musicSource.volume = 0.2f;
            }
            else
            {
                musicSource.volume = 0;
            }
        }

    }
    
}
