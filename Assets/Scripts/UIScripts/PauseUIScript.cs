using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUIScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void ResumeButtonEvent()
    {
        GameManager.gameManager.TogglePause();
    }
    public void RestartButtonEvent()
    {
        GameManager.gameManager.ReloadScene();
        GameManager.gameManager.TogglePause();
    }
    public void MenuButtonEvent()
    {
        GameManager.gameManager.TogglePause();
        GameManager.gameManager.TogglePlay(false);
        GameManager.gameManager.ChangeScene("MenuScene");
    }
}
