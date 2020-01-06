using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{
    public int Level = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Void" || collision.gameObject.tag == "Spike")// || collision.gameObject.tag == "Exit")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        /*if(collision.gameObject.tag == "Portal" && Level == 1)
        {
            SceneManager.LoadScene("Level2");
        }
        if (collision.gameObject.tag == "Portal" && Level == 2)
        {
            SceneManager.LoadScene("MainMenu");
        } */
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
