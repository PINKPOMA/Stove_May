using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class SoundManager : MonoBehaviour
{

    public static SoundManager instance;

    private AudioSource audioSource;
    

    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip dieSound;
    [SerializeField] private AudioClip buttonClickSound;
    [SerializeField] private AudioClip clockSound;
    [SerializeField] private AudioClip titleBgmSound;
    [SerializeField] private AudioClip mainBgmSound;
    [SerializeField] private AudioClip endBgmSound;

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

    public void PlayButtonClickSound()
    {
        audioSource.PlayOneShot(buttonClickSound);
    }

    public void PlayClockSound()
    {
        audioSource.PlayOneShot(clockSound);
    }

    public void PlayBGM(string sceneName)
    {
        switch (sceneName)
        {
            case "Title":
                audioSource.Stop();
                audioSource.PlayOneShot(titleBgmSound);
                audioSource.loop = true;
                break;
            case "YB_Main":
                audioSource.Stop();
                audioSource.PlayOneShot(mainBgmSound);
                audioSource.loop = true;
                break;
            case "BedEnding":
            case "HighScore":
                audioSource.Stop();
                audioSource.PlayOneShot(endBgmSound);
                audioSource.loop = true;
                break;
        }
    }
}
