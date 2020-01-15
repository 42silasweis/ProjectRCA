using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintParticlesScript : MonoBehaviour
{
    bool sprint;
    bool playerGrounded;
    float timer;
    public float delay = 0.2f;
    public GameObject particle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerGrounded = gameObject.GetComponentInParent<DifferentJump>().grounded;
        sprint = gameObject.GetComponentInParent<DifferentJump>().sprintKeyDown;
        timer += Time.deltaTime;
        if (Input.GetButton("Horizontal") && timer > delay && sprint && playerGrounded)
        {
            timer = 0;
            Instantiate(particle, transform.position, transform.rotation);
        }
    }
}
