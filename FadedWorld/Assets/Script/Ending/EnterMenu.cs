using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnterMenu : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SoundManager.instance.PlayBGM("Title");
            SceneManager.LoadScene(1);
            var score = GameObject.FindWithTag("Score").GetComponent<SurviveTime>();
            score.nowScore = 0;
        }
    }
}
