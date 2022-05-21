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
    public int maxScore;
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
                    maxScore = (int)surviveTime;
                    oneScene = true;
                    surviveTime = 0;
                    isDead = false;
                    SceneManager.LoadScene(3);

                }
                else
                {
                    oneScene = true;
                    surviveTime = 0;
                    isDead = false;
                    SceneManager.LoadScene(2);
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
