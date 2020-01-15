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
    private float moveInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");
        playerGrounded = gameObject.GetComponentInParent<DifferentJump>().grounded;
        sprint = gameObject.GetComponentInParent<DifferentJump>().sprintKeyDown;
        timer += Time.deltaTime;
        if (Input.GetButton("Horizontal") && timer > delay && sprint && playerGrounded && moveInput < 0)
        {
            timer = 0;
            Instantiate(particle, transform.position, transform.rotation);
        }
        if (Input.GetButton("Horizontal") && timer > delay && sprint && playerGrounded && moveInput > 0)
        {
            timer = 0;
            Instantiate(particle, transform.position - (Vector3.right * 1.0f), transform.rotation);
        }
    }
}
