using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManagerUIScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Image healthBar;
    [SerializeField]
    Text Score;
    [SerializeField]
    StageManager stageManager;
    [SerializeField]
    HealthManage healthManage;
    public void ExEvent()
    {
        GameManager.gameManager.ChangeScene("SampleScene");
    }

    private void Update()
    {
        Score.text = "S: " + stageManager.StageScore;
        healthBar.fillAmount = healthManage.currentHealth / healthManage.MaxHealth;
    }

}

    // Update is called on