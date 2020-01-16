using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripplebulletScript : MonoBehaviour
{
    GameObject Player;
    float bulletspeed;
    Vector3 rb;
    bool direction;

    void Start()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        direction = Player.GetComponent<DifferentJump>().dir;
        rb = Player.GetComponent<Rigidbody2D>().velocity;
        rb.y = 0;
        float x = Input.GetAxisRaw("Horizontal");
        bulletspeed = Player.GetComponent<PlayerShoot>().bulletSpeed;
        //GetComponent<Rigidbody2D>().velocity = transform.right * bulletspeed;
        if (x > 0)
        {
            GetComponent<Rigidbody2D>().velocity = (transform.right * bulletspeed) + rb;
        }

        if (x < 0)
        {
            GetComponent<Rigidbody2D>().velocity = (-transform.right * bulletspeed) + rb;
        }

        else if (x == 0 && direction == true)
        {
            GetComponent<Rigidbody2D>().velocity = transform.right * bulletspeed;
        }
        else if (x == 0 && direction == false)
        {
            GetComponent<Rigidbody2D>().velocity = -transform.right * bulletspeed;
        }
    }
}
