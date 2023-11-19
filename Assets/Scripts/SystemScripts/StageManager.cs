using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{

    public int StageScore;
    public float StageTime = 0;

    float scoreReduceCounter = 1;

    [SerializeField] int StageNum;//스테이지 번호

    [SerializeField] public int InitialScore = 2000; // 초기 점수

    [SerializeField] public int ScoreMinSeconds = 30; // 초당 차감 점수

    [SerializeField] public float MapSizeX;

    [SerializeField] public float MapSizeY;//맵 크기 지정

    [SerializeField] GameObject endPoint;//도착지 지정
    // Start is called before the first frame update

    private void Awake()
    {
    }
    void Start()
    {
        GameManager.gameManager.TogglePlay(true);
        StageScore = InitialScore;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel")&&GameManager.gameManager.isGamePlaying) { GameManager.gameManager.TogglePause(); }

        StageTime += Time.deltaTime;
        scoreReduceCounter -= Time.deltaTime;
        if (scoreReduceCounter <= 0)
        {
            scoreReduceCounter = 1;
            StageScore -= ScoreMinSeconds;
        }
    }
    public void FinishStage()
    {
        GameManager.gameManager.ScoreUpdate(GameManager.gameManager.currentStage, StageScore);
        GameManager.gameManager.TogglePlay(false);
        GameManager.gameManager.loader.LoadScene("NextStage", UnityEngine.SceneManagement.LoadSceneMode.Additive);
    }

    public void GameOverStage()
    {
        GameManager.gameManager.TogglePlay(false);
        GameManager.gameManager.loader.LoadScene("GameOver", UnityEngine.SceneManagement.LoadSceneMode.Additive);
    }
}
