using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverUIScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    TextMeshProUGUI Stage;
    private void Start()
    {
        Stage.text = "Stage "+(GameManager.gameManager.currentStage + 1); 
    }
    public void RestartButtonScript()
    {
        GameManager.gameManager.ReloadScene();
        GameManager.gameManager.loader.UnloadScene("GameOver");//���� ���� â ����
    }
    public void MenuButtonScript()
    {
        GameManager.gameManager.ChangeScene("MenuScene");
    }
}
