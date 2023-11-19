using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

//Initialized

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    [SerializeField]
    public SceneLoader loader;
    [SerializeField]
    public int StageCnt = 3;//�������� ��
    [SerializeField]
    public int currentStage = 0;//���� ��������
    public int currentScore;

    public bool[] StageClear;//�������� Ŭ���� ����
    public int[] StageRecord;//�������� ���


    //���� ���� ����
    public bool isGravityReversed = false;//�߷� ���� ����(�̻��)
    public bool isGamePlaying = false;//���� ���� �� ����
    public bool isGamePaused = false;//���� �Ͻ����� ����

    private void Awake()
    {
        gameManager = this;
        DontDestroyOnLoad(gameObject);

        StageClear = new bool[StageCnt];
        StageRecord = new int[StageCnt];

        loader = new SceneLoader();
    }
    // Start is called before the first frame update
    void Start()
    {
        loader.NextScene("MenuScene");//���� �޴� �ҷ�����
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TogglePlay(bool var)
    {
        Time.timeScale = (var == false) ? 0f : 1f;
        isGamePlaying = var;
        isGamePaused = false;
    }
    public void TogglePause()
    {
        isGamePaused = !isGamePaused;
        if (isGamePaused)
        {
            Time.timeScale = 0f;
            loader.LoadScene("PauseScene",LoadSceneMode.Additive);
        }
        else
        {
            Time.timeScale = 1f;
            loader.UnloadScene("PauseScene");
        }

    }
    public void ChangeScene(string name)
    {
        loader.NextScene(name);
    }

    public void ReloadScene()
    {
        loader.ReloadScene();
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void ScoreUpdate(int stage, int score)
    {
        currentScore = score;
        if (score > StageRecord[stage])
        {
            StageRecord[stage] = score;
        }
    }
}
