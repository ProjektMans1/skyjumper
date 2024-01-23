using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
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

        //sprawdzenie czy dotyka ziemii
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, Ground);

        Jump();



    }


    void Jump()
    {
        //skakanie
        if (isGrounded == true && Input.GetKeyUp(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce * jumpStartTime;
            jumpStartTime = 0;
            holdSpace = false;
            canMove = true;
        }
        //przytrzymanie spacji zwiêksza jumpforce'a
        if (isGrounded == true && Input.GetKey(KeyCode.Space))
        {
            canMove = false;
            holdSpace = true;
            jumpStartTime += Time.deltaTime * 1.3f;
        }


    }
}

