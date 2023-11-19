using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NextStageUIScript : MonoBehaviour
{
    [SerializeField]
    Button nextStageButton;
    [SerializeField]
    TextMeshProUGUI stage;
    [SerializeField]
    TextMeshProUGUI score;
    //[SerializeField]
    //StageManager stageManager;
    // Start is called before the first frame update
    private void Start()
    {
        if(GameManager.gameManager.currentStage == GameManager.gameManager.StageCnt-1)
        {
            nextStageButton.interactable = false;//스테이지가 마지막 스테이지일 경우 다음 스테이지 버튼 비활성화
        }
        stage.text = "Stage " + (GameManager.gameManager.currentStage + 1);
        if(GameManager.gameManager.currentScore == GameManager.gameManager.StageRecord[GameManager.gameManager.currentStage])
        {
            score.text = "Score: " + GameManager.gameManager.currentScore;//최고 기록일 경우 현재 점수만
        }
        else
        {
            score.text = "Record: " + GameManager.gameManager.StageRecord[GameManager.gameManager.currentStage]
                + "\nScore " + GameManager.gameManager.currentScore;//그렇지 않을 경우 기록도 같이 표시
            
        }
    }

    public void NextStageButtonEvent()
    {
        GameManager.gameManager.currentStage++;//스테이지 증가
        GameManager.gameManager.ChangeScene("Stage" + GameManager.gameManager.currentStage);//다음 스테이지로 전환
    }
    public void MenuButtonEvent()
    {
        GameManager.gameManager.ChangeScene("MenuScene");
    }
}