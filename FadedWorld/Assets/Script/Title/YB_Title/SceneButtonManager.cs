using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneButtonManager : MonoBehaviour
{
    private bool isActive;
    
    [SerializeField]private Text explainText;
    [SerializeField] private GameObject HelpMessagePanel;
    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    
    public void MainButton()
    {
        SceneManager.LoadScene(0);
    }
    
    
    
   public void OnClickHelpButton()
   {
       isActive = !isActive;
        HelpMessagePanel.SetActive(isActive);
    }

   public void OnClickNextButton()
   {
       explainText.text = "생존 가능 시간: 회색에서 버틸 수 있는 시간입니다. (10초)\n\n" +
                          "시계: 생존 가능 시간을 5초 추가해줍니다.\n\n" +
                          "회색 지대, 회색 비: 닿아있으면 생존 가능 시간이 줄어듭니다.\n\n" +
                          "가시: 밟으면 3초 동안 이동속도가 절반이 됩니다.\n\n" +
                          "떨어지거나 생존 가능 시간이 0초가 된다면 게임 오버입니다.";
   }

   public void OnClickPerivousButton()
   {
       explainText.text = "이동 방법: a, d\n\n" +
                          "점프: space (최대 2번)\n\n" +
                          "걷기: shift키 누른 상태로 이동\n\n" +
                          "Help 버튼을 다시 눌러 도움말을 종료할 수 있습니다.";
   }
}
