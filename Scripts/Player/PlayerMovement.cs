using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody playerRb;
    public float x_speed = 200f;
    public float z_speed = 150f;
    public float jumpForce = 20;
    private bool isWalk;
    private PlayerAnimation animScript;
    private float walk_rotate = 90f;
    public bool isGrounded;



    private void Start()
    {
        isGrounded = true;
    }
    void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
        animScript = GetComponentInChildren<PlayerAnimation>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (PlayerAttack.canMove)
        {
            MovePlayer();            
        }
        JumpPlayer();
        WalkAnimation();
        RotateWhenWalking();
    }


    public void MovePlayer()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        playerRb.velocity = new Vector3(
            horizontal * (-x_speed) * Time.deltaTime,
            playerRb.velocity.y,
            vertical * (-z_speed) * Time.deltaTime);


    }
    public void JumpPlayer()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            animScript.Jump();
        }
    }
    

    private void WalkAnimation()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 
            || Input.GetAxisRaw("Vertical")!= 0)
        {
            animScript.Walk(true);
        }
        else
        {
            animScript.Walk(false);
        }
    }


    private void RotateWhenWalking()
    {
        if (Input.GetAxisRaw("Horizontal") > 0) // move right            
        {
            playerRb.rotation = Quaternion.Euler(0f, -walk_rotate, 0f); 
        }

        if (Input.GetAxisRaw("Horizontal") < 0) // move left            
        {
            playerRb.rotation = Quaternion.Euler(0f, walk_rotate, 0f);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;           
        }
    }
}
