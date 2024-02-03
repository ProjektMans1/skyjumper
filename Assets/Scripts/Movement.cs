using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public LayerMask Ground;
    public Transform feetPos;
    private Rigidbody2D rb;

    public float speed = 2f;
    private float moveInput;
    private bool isGrounded;
    public float jumpStartTime = 1f;
    public float jumpForce = 5f;
    private bool canMove = true;

    public float checkRadius;



    private bool holdSpace;

    public Animator animator;
    public bool isDie = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();


    }

    // Update is called once per frame
   private void FixedUpdate()
    {
        if (canMove)
        {
            moveInput = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        }

    } 

    void Update()
    {

        //Zmienne do animatora
        animator.SetBool("holdSpace", holdSpace);
        animator.SetBool("grounded", isGrounded);
        animator.SetFloat("walking", moveInput);
        animator.SetBool("die", isDie);

        //sprawdzenie czy dotyka ziemii
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, Ground);

        Jump();



    }

    float countTimeSpace = 1;
    private float keyTimer = 0;
    void Jump()
    {
        //skakanie
        if (isGrounded == true && Input.GetKeyUp(KeyCode.Space))
        {
            JustJump(); 
        }

       
        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            keyTimer = Time.time;
        }

        //przytrzymanie spacji zwiêksza jumpforce'a
        if (isGrounded == true && Input.GetKey(KeyCode.Space))
        {
            canMove = false;
            holdSpace = true;
            countTimeSpace = Time.deltaTime + 1;

            
            Debug.Log(Time.time - keyTimer);

            if (Time.time - keyTimer >= 3)
            {
                
            }
            else
            {
                jumpStartTime += Time.deltaTime * 1.3f;
            }


        }

    }
    void JustJump()
    {
        rb.velocity = Vector2.up * jumpForce * jumpStartTime;
        jumpStartTime = 0;
        holdSpace = false;
        canMove = true;
        countTimeSpace = 0;
    }
 
}

