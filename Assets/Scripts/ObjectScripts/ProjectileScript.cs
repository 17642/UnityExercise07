using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    [SerializeField]
    private float Force;
    [SerializeField]
    private float ColideForce;//�浹�� �������� ��
    [SerializeField]
    private float RemainTime;

    private Vector2 direction;//����

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject, RemainTime);
        if (collision.gameObject.CompareTag("Object"))
        {
            Rigidbody2D ORigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            if(ORigidbody != null)
            {
                ORigidbody.AddForce(-direction * ColideForce);
            }
        }
        if (!(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Cosmetics")))
        {
            Destroy(gameObject);
        }
    }

    public void ShootProj(Vector2 direction)
    {
        this.direction = direction;
        gameObject.GetComponent<Rigidbody2D>().AddForce(direction * Force, ForceMode2D.Impulse);
    }
}
