using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SurviveTime : MonoBehaviour
{
    [Header("Survive")]
    public float surviveTime;
    [SerializeField] private int maxScore;
    [SerializeField] private Text timeText;
    [Space]
    [Header("Start")]
    [SerializeField] Text startTime;
    public bool isDead;

    private void Start()
    {
      //  Time.timeScale = 0;
        //StartCoroutine(StartCount());
    }

    IEnumerator StartCount()
    {
        for (int i = 3; i >= 0; i--)
        {
            startTime.DOFade(1, 1f);
            startTime.text = i.ToString();
            startTime.DOFade(0, 1f);
            Debug.Log(i);
            yield return new WaitForSeconds(1f);
        }
        startTime.text = "Start!";
        startTime.DOFade(0, 2f);
        Time.timeScale = 1;
    }
    private void Update()
    {
        if (isDead)
        {
            if (maxScore < (int)surviveTime)
            {
                SceneManager.LoadScene(3);
            }
            else
            {
                SceneManager.LoadScene(2);
            }
        }
        else
        {
            Timep();
        }
    }

    void Timep()
    {
        surviveTime += Time.deltaTime;
        timeText.text = $"생존시간: {String.Format("{0:N0}", surviveTime)}s";
    }
}
