using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private float MoveSpeed;
    [SerializeField]
    private float JumpForce;
    [SerializeField]
    private float RayLength;
    [SerializeField]
    private int MaxHealth;
    [SerializeField]
    private float ShotDelay;
    [SerializeField]
    GameObject Projectile;
    [SerializeField]
    private float ProjLocationY;
    [SerializeField]
    private float animationInputVar=0.1f;


    Animator animator;

    bool playerIsMoving = false;
    bool playerOnGround = false;
    bool playerLookingRight = true;

    float ShotTime = 0;
    float horizontalInput;
    Vector2 movement;

    int currentHealth;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("LookingRight", playerLookingRight);
        animator.SetBool("OnAir", !playerOnGround);
        animator.SetBool("Moving", playerIsMoving);
        CheckGround();
        PlayerMove();
        if (playerOnGround&&Input.GetButtonDown("Jump")) { playerJump(); }
        if (ShotTime <= 0 && Input.GetKeyDown(KeyCode.V))
        {
            animator.SetTrigger("Shoot");
            ShootProj();
            ShotTime = ShotDelay;
        }else if (ShotTime < 0)
        {
            ShotTime = 0;
        }
        else
        {
            ShotTime -= Time.deltaTime;
        }
    }

    void PlayerMove()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput < animationInputVar*-1)
        {
            playerLookingRight = false;
        }
        else if(horizontalInput > animationInputVar)
        {
            playerLookingRight = true;
        }
        movement = new Vector2(horizontalInput, 0) * MoveSpeed;

        transform.Translate(movement * Time.deltaTime);

        if (horizontalInput != 0)
        {
            playerIsMoving = true;
        }
        else
        {
            playerIsMoving = false;
        }
    }

    void playerJump()
    {
        animator.SetTrigger("Jump");
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, JumpForce);
    }

    void CheckGround()
    {
        int layermask = LayerMask.GetMask("Ground");
        playerOnGround = Physics2D.Raycast(transform.position, Vector2.down, RayLength,layermask);
    }

    void ShootProj()
    {
        Vector2 sd;
        if (playerLookingRight)
        {
            sd = Vector2.right;
        }
        else
        {
            sd = Vector2.left;
        }
        Vector2 projPosition = new Vector2(transform.position.x, transform.position.y + ProjLocationY);
        projPosition.x += sd.x * 0.1f;

        GameObject proj = Instantiate(Projectile, projPosition, Quaternion.identity);

        ProjectileScript Pjscript = proj.GetComponent<ProjectileScript>();
        Pjscript.ShootProj(sd);



    }
}


