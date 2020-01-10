using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPlatformMove : MonoBehaviour
{
    public float moveXSpeed = 3f;
    public float moveYSpeed = 0.0f;
    bool moveRight = true;
    bool moveUp = true;
    public float paceDistance = 3.0f;
    Vector3 startPosition;
    public bool movesUpAndDown;

    void Start()
    {
        startPosition = transform.position;
    }
    void Update()
    {
        Vector3 displacement = transform.position - startPosition;
        if (displacement.magnitude >= paceDistance)
        {
            moveRight = !moveRight;
            moveUp = !moveUp;
        }
        /*
        if (transform.position.x > 4f)
        {
            moveRight = false;
        }
        if (transform.position.x > -4f)
        {
            moveRight = true;
        }
        */
        if (moveRight)
        {
            transform.position = new Vector2(transform.position.x + moveXSpeed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - moveXSpeed * Time.deltaTime, transform.position.y);
        }

        if (moveUp)
        {
            transform.position = new Vector2(transform.position.y + moveYSpeed * Time.deltaTime, transform.position.x);
        }
        else
        {
            transform.position = new Vector2(transform.position.y - moveYSpeed * Time.deltaTime, transform.position.x);
        }
    }
}
