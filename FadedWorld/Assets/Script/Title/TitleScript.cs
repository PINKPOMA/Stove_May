using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleScript : MonoBehaviour
{
    [SerializeField]private Text timeText;
    void Start()
    {
        var score = GameObject.FindWithTag("Score").GetComponent<SurviveTime>();
        score.nowScore = 0;
        timeText.text = $"최고기록: {score.highScore}초";
    }
}
