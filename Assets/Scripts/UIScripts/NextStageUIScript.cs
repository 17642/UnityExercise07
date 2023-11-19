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
            nextStageButton.interactable = false;//���������� ������ ���������� ��� ���� �������� ��ư ��Ȱ��ȭ
        }
        stage.text = "Stage " + (GameManager.gameManager.currentStage + 1);
        if(GameManager.gameManager.currentScore == GameManager.gameManager.StageRecord[GameManager.gameManager.currentStage])
        {
            score.text = "Score: " + GameManager.gameManager.currentScore;//�ְ� ����� ��� ���� ������
        }
        else
        {
            score.text = "Record: " + GameManager.gameManager.StageRecord[GameManager.gameManager.currentStage]
                + "\nScore " + GameManager.gameManager.currentScore;//�׷��� ���� ��� ��ϵ� ���� ǥ��
            
        }
    }

    public void NextStageButtonEvent()
    {
        GameManager.gameManager.currentStage++;//�������� ����
        GameManager.gameManager.ChangeScene("Stage" + GameManager.gameManager.currentStage);//���� ���������� ��ȯ
    }
    public void MenuButtonEvent()
    {
        GameManager.gameManager.ChangeScene("MenuScene");
    }
}