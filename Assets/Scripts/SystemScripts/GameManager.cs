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
    public int StageCnt = 3;//스테이지 수
    [SerializeField]
    public int currentStage = 0;//현재 스테이지
    public int currentScore;

    public bool[] StageClear;//스테이지 클리어 여부
    public int[] StageRecord;//스테이지 기록


    //게임 내부 설정
    public bool isGravityReversed = false;//중력 반전 여부(미사용)
    public bool isGamePlaying = false;//게임 진행 중 여부
    public bool isGamePaused = false;//게임 일시정지 여부

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
        loader.NextScene("MenuScene");//시작 메뉴 불러오기
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
