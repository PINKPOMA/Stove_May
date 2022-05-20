using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SurviveTime : MonoBehaviour
{
    [SerializeField] private float surviveTime;
    [SerializeField] private int maxScore;
    [SerializeField] private Text timeText;
    public bool isDead;
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
