using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody2D enemyRigidBody2D;
    public float enemySpeed = 2;
    bool grounded;
    bool leftFootGrounded;
    bool rightFootGrounded;
    Animator anim;
    bool moveRight = true;
    public float paceDistance = 4.0f;
    Vector3 startPosition;
    bool wentOffEdge;
    bool wentOffEdge2;

    private void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    public void Update()
    {
        leftFootGrounded = gameObject.GetComponentInChildren<EnemyFeetGrounded2>().grounded;
        rightFootGrounded = gameObject.GetComponentInChildren<EnemyFeetGrounded>().grounded;

        Vector3 displacement = transform.position - startPosition;
        if (displacement.magnitude >= paceDistance)
        {
            moveRight = !moveRight;
        }
        if(rightFootGrounded == false && wentOffEdge == false)
        {
            moveRight = !moveRight;
            wentOffEdge = true;
            wentOffEdge2 = false;
        }

        if (leftFootGrounded == false && wentOffEdge2 == false)
        {
            moveRight = !moveRight;
            wentOffEdge2 = true;
            wentOffEdge = false;
        }

        if (moveRight)
        {
            transform.position = new Vector2(transform.position.x + enemySpeed * Time.deltaTime, transform.position.y);
            Debug.Log("If moveRight");
        }
        else
        {
            transform.position = new Vector2(transform.position.x - enemySpeed * Time.deltaTime, transform.position.y);
            Debug.Log("Else if MoveRight");
        }

        Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
        anim.SetBool("grounded", grounded);
        anim.SetFloat("x", velocity.x);
        anim.SetFloat("y", velocity.y);

        float x = Input.GetAxisRaw("Horizontal");
        if (x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 0 && !collision.isTrigger)
        {
            grounded = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 0 && !collision.isTrigger)
        {
            grounded = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 0 && !collision.isTrigger)
        {
            grounded = false;
        }
    }
}
