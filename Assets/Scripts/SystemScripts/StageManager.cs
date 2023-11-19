using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{

    public int StageScore;
    public float StageTime = 0;

    float scoreReduceCounter = 1;

    [SerializeField] int StageNum;//�������� ��ȣ

    [SerializeField] public int InitialScore = 2000; // �ʱ� ����

    [SerializeField] public int ScoreMinSeconds = 30; // �ʴ� ���� ����

    [SerializeField] public float MapSizeX;

    [SerializeField] public float MapSizeY;//�� ũ�� ����

    [SerializeField] GameObject endPoint;//������ ����
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
