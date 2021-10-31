using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    private AudioSource audSource;
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

    public void PlayClip(AudioClip audClip)
    {
        audSource.PlayOneShot(audClip);
    }
}
