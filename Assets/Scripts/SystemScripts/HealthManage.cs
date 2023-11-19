using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManage : MonoBehaviour
{
    [SerializeField]
    public float MaxHealth;
    [SerializeField]
    StageManager stageManager;

    public float currentHealth;

    private void Start()
    {
        currentHealth = MaxHealth;
    }
    // Start is called before the first frame update
    public void TakeDamage(float dmg)
    {
        currentHealth -= dmg;
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
        if (currentHealth <= 0)
        {
            Dead();
        }
    }
}
