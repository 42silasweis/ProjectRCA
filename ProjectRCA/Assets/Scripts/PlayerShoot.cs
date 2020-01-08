using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject prefab;
    public float bulletSpeed = 10.0f;
    public float bulletLifeTime = 1.0f;
    public float shootDelay = 0.5f;
    float timer = 0;
    public int ammoCount = 10;
    public int maxAmmo = 10;
    bool direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = gameObject.GetComponent<DifferentJump>().dir;
        float x = Input.GetAxisRaw("Horizontal");
        timer += Time.deltaTime;
        if (Input.GetButton("Fire2") && timer > shootDelay && ammoCount > 0)
            //if left click do something
        {
            timer = 0;
            GameObject bullet = Instantiate(prefab, transform.position, Quaternion.identity);
            ammoCount--;

            if (x > 0)
             {
                bullet.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;
             }

            if (x < 0)
            {
                bullet.GetComponent<Rigidbody2D>().velocity = -transform.right * bulletSpeed;
            }

            else if (x == 0 && direction == true)
            {
                bullet.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;
            }
            else if (x == 0 && direction == false)
            {
                bullet.GetComponent<Rigidbody2D>().velocity = -transform.right * bulletSpeed;
            }

            Destroy(bullet, bulletLifeTime);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ammo" && ammoCount < 10)
        {
            ammoCount++;
            Destroy(collision.gameObject);
        }
    }
}
