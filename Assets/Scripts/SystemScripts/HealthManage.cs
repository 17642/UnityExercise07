using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManage : MonoBehaviour
{
    [SerializeField]
    public float MaxHealth;
    [SerializeField]
    StageManager stageManager;
    [SerializeField]
    private float imminueTime=0.5f;

    public float currentHealth;
    float imminueCounter = 0;

    private void Start()
    {
        currentHealth = MaxHealth;
    }
    // Start is called before the first frame update
    public void TakeDamage(float dmg)
    {
        if (imminueCounter == 0)
        {
            currentHealth -= dmg;
            imminueCounter = imminueTime;
        }
    }

    public void Dead()
    {
        if (gameObject.CompareTag("Player"))
        {
            stageManager.GameOverStage();
            currentHealth = MaxHealth;//체력 초기화
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (imminueCounter > 0)
        {
            imminueCounter -= Time.deltaTime;
            if (imminueCounter < 0)
            {
                imminueCounter = 0;
            }
        }
        if (currentHealth <= 0)
        {
            Dead();
        }
    }
}
