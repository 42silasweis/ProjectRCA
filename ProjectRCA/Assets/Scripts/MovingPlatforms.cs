using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
    public bool currentPos = true;
    bool posMoved = false;
    bool posMoved2 = false;
    public Transform plat1;
    public Transform plat2;
    // Start is called before the first frame update
    void Start()
    {
        plat1.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPos == true)
        {
            MoveLeft();
            posMoved = true;
            posMoved2 = false;
        }
        if (currentPos == false)
        {
            MoveRight();
            posMoved2 = true;
            posMoved = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E) && collision.gameObject.tag == "Player" && !collision.isTrigger)
        {
            currentPos = !currentPos;
        }
    }
    void MoveLeft()
    {
        if (posMoved == false)
        {
            Vector3 v3 = transform.position;
            v3.x += 2.0f;
            plat1.transform.position = v3;
        }
    }
    void MoveRight()
    {
        if (posMoved2 == false)
        {
            Vector3 v3 = transform.position;
            v3.x -= 2.0f;
            plat1.transform.position = v3;
        }
    }
}
