using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuUIScript : MonoBehaviour
{
    [SerializeField]
    Image TutorialPanel;

    bool tutorialPanelActive = false;

    public void StageSelectButtonEvent()
    {
        GameManager.gameManager.ChangeScene("StageSelect");
    }

    public void HowToPlayButtonEvent()
    {
        TutorialPanelToggle();
    }

    public void ExitButtonEvent()
    {
        GameManager.gameManager.Exit();
    }

    void TutorialPanelToggle()
    {
        tutorialPanelActive = !tutorialPanelActive;
        TutorialPanel.gameObject.SetActive(tutorialPanelActive);
    }
}
