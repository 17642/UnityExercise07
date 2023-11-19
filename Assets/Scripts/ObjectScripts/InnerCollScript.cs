using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerCollScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    BoxScript outerBox;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<HealthManage>().TakeDamage(outerBox.Damage);
        }
    }
}
