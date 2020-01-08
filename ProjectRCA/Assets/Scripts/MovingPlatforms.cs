using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
    public bool currentPos;
    bool posMoved;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if()
    }
    void MoveLeft()
    {
        if (currentPos == true && posMoved == false)
        {
            Vector3 v3 = transform.position;
            v3.x += 20.0f;
            transform.position = v3;
        }
    }
}
