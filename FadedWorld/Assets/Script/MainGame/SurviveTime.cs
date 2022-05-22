using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SurviveTime : MonoBehaviour
{
    private static SurviveTime instance = null;
    [Header("Survive")]
    public float surviveTime;
    public int maxScore = 0;
    private Text timeText;
    public bool isDead;
    private bool oneScene;
    private Text highScoreText;
    void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public static SurviveTime Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Title")
        {
            surviveTime = 0;
        }
        if (SceneManager.GetActiveScene().name == "YB_Main")
        {
            var wal = GameObject.Find("GrayWall").GetComponent<Wall>();
            if (!wal.isWark)
            {
                surviveTime = 0;
            }
        }
        if (SceneManager.GetActiveScene().name == "BadEnding" || SceneManager.GetActiveScene().name == "HighScore")
        {
            oneScene = false;
        }
        if (isDead)
        {
            if (!oneScene)
            {
                Debug.Log("발동");
                if (maxScore < (int)surviveTime)
                {
                    oneScene = true;
                    maxScore = (int)surviveTime;
                    surviveTime = 0;
                    isDead = false;
                    SoundManager.instance.PlayBGM("BadEnding");
                    SceneManager.LoadScene(4);

                }
                else
                {
                    oneScene = true;
                    surviveTime = 0;
                    isDead = false;
                    SoundManager.instance.PlayBGM("HighScore");
                    SceneManager.LoadScene(3);
                }
            }
        }
        else
        {
            Timep();
        }
    }

    void Timep()
    {
        timeText = GameObject.FindWithTag("timeT")?.GetComponent<Text>();
        surviveTime += Time.deltaTime;
        timeText.text = $"생존시간: {String.Format("{0:N0}", surviveTime)}s";
    }
}
