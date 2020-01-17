using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public int Level = 1;
    public int health = 4;
    int initialHealth;
    public Text healthText;
    public Text liveText;


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
            health--;
            healthText.text = "HP: " + health + "/" + initialHealth;
            if (health < 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        initialHealth = health;
        healthText.text = "HP: " + health + "/" + initialHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
