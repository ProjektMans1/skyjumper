using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    private float moveInput;
    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask Ground;
    public bool doubleJump;

    public bool canMove = true;
    public float jumpStartTime;
    private bool holdSpace;

    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Poruszanie w poziomie
        if(canMove)
        {
            moveInput = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        }
       
    }

    void Update()
    {
        animator.SetBool("holdSpace", holdSpace);
        animator.SetBool("grounded", isGrounded);

        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, Ground);
        //if do sprzawdzenia doubleJump'a
        if (isGrounded)
        {
            doubleJump = false;
        }

        //skakanie
        if (isGrounded == true && Input.GetKeyUp(KeyCode.Space))
        {
            canMove = true;
            rb.velocity = Vector2.up * jumpForce * jumpStartTime;
            jumpStartTime = 0;
            holdSpace = false;
        }
        //przytrzymanie spacji zwiêksza jumpforce'a
        if (isGrounded == true && Input.GetKey(KeyCode.Space))
        {
            holdSpace = true;
            jumpStartTime += Time.deltaTime;
            canMove = false;
        }
        



        //podwójny skok - mo¿e siê przyda
        /*if (!isGrounded && !doubleJump && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
            doubleJump = true;
        }*/
    }

    void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
    }

}
