using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnterMenu : MonoBehaviour
{
    public Text sct;
    void Update()
    {
        var scoreMaster = GameObject.FindWithTag("Score").GetComponent<SurviveTime>();
        sct.text = $"최고기록: {scoreMaster.maxScore}초";
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(0);
        }
    }
    
    
}
