using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SoundManager : MonoBehaviour
{

    public static SoundManager instance;

    private AudioSource audioSource;
    

    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip dieSound;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    public void PlayJumpSound()
    {
        audioSource.PlayOneShot(jumpSound);
    }

    public void PlayDieSound()
    {
        audioSource.PlayOneShot(dieSound);
    }
}
