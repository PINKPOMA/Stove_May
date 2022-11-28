using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SurviveTime : Singleton<SurviveTime>
{
    public int highScore;
    public int nowScore;
    private Text highScoreText;
    

    public void SetTime()
    {
        if (highScore < nowScore)
        {
            highScore = nowScore;
            SoundManager.instance.PlayBGM("HighScore");
        }
        else
        {
            SoundManager.instance.PlayBGM("BadEnding");
        }
        
        SceneManager.LoadScene(3);
    }
}
