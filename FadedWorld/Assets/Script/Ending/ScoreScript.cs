using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
  [SerializeField] private Text highScoreText;
  [SerializeField] private Text nowScoreText;

  private void Start()
  {
    var scoreManager = GameObject.FindWithTag("Score").GetComponent<SurviveTime>();
    highScoreText.text = $"최고기록: {scoreManager.highScore}초";
    nowScoreText.text = $"현재기록: {scoreManager.nowScore}초";
    
  }
}
