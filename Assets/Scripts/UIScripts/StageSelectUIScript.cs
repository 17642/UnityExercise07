using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StageSelectUIScript : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI[] ScoreField;
    [SerializeField]
    Button[] StageSelectButton;

    private void Start()
    {
        for(int i = 0; i < GameManager.gameManager.StageCnt; i++)
        {
            ScoreField[i].text = "R: " + GameManager.gameManager.StageRecord[i];
        }
        for(int i = 1; i < GameManager.gameManager.StageCnt; i++)
        {
            StageSelectButton[i].interactable = GameManager.gameManager.StageClear[i-1];//1�� ���������� �����ϰ� ���� �������� Ŭ���� �� ���� �������� ���� ����
        }
    }
    public void StageButton(int stageNum)
    {
        GameManager.gameManager.currentStage = stageNum;
        GameManager.gameManager.ChangeScene("Stage" + stageNum);//�������� ��ȣ�� ���� �� ��ȯ
    }
    public void ExStart()
    {
        GameManager.gameManager.ChangeScene("SampleScene");
    }

    public void MenuButtonScript()
    {
        GameManager.gameManager.ChangeScene("MenuScene");
    }
}
