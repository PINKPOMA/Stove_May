using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainTimer : MonoBehaviour
{
    [SerializeField] private Text nowTimeText;
    private float nowTime;

    private void Update()
    {
        nowTime += Time.deltaTime;
        nowTimeText.text = $"생존시간: {(int)nowTime}s";
    }

    public void Dead()
    {
        var surviveTime = GameObject.FindWithTag("Score").GetComponent<SurviveTime>();
        surviveTime.nowScore = (int)nowTime;
        surviveTime.SetTime();
    }
}
