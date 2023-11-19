using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    //private bool isGravityReversed = false;

    [SerializeField]
    public float Damage = 1;

    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            //gameManager.isGravityReversed = !gameManager.isGravityReversed;//상태 반전
            ToggleGravity();
        }

        void ToggleGravity()
        {
            rb.gravityScale *= -1;//중력 반전
        }

    }
}
