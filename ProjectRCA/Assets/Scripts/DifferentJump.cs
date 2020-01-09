﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifferentJump : MonoBehaviour
{
    public float speed = 7;
    public float jumpForce;
    private float moveInput;
    private Rigidbody2D rb;

    private bool facingRight = true;

    public bool grounded;

    //public bool isGrounded;
    //public Transform groundCheck;
    //public float checkRadius;
    //public LayerMask whatIsGround;

    public int extraJumps;
    public int extraJumpsValue;

    float initialMoveSpeed;
    public float sprintMultiplier = 2;
    float sprintSpeed;
    bool sprintKeyDown = false;
    public bool dir;

    private void Start()
    {
        initialMoveSpeed = speed;
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        //isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (facingRight == false && moveInput > 0)
        {
            Flip();
            dir = true;
        }
        else if(facingRight == true && moveInput < 0)
        {
            Flip();
            dir = false;
        }

    }
    private void Update()
    {
        if(grounded == true)
        {
            extraJumps = extraJumpsValue;
        }
        if (Input.GetButtonDown("Jump") && extraJumps > 0 && grounded == false)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if (Input.GetButtonDown("Jump") && grounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (sprintKeyDown == false)
            {
                sprintKeyDown = true;
                speed = speed * sprintMultiplier;
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = initialMoveSpeed;
            sprintKeyDown = false;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 0)
        {
            grounded = true;
            extraJumps = extraJumpsValue;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 0)
        {
            grounded = true;
            extraJumps = extraJumpsValue;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 0)
        {
            grounded = false;
            //jumpCount = 0;
        }
    }
}