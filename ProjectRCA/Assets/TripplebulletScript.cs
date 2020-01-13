using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripplebulletScript : MonoBehaviour
{
    GameObject Player;
    float bulletspeed;
    Vector3 rb;

    void Start()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        bulletspeed = Player.GetComponentInChildren<PlayerShoot>().bulletSpeed;
        GetComponent<Rigidbody2D>().velocity = (transform.right * bulletspeed);
    }
}
