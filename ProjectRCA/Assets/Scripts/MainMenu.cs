using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int hardModeEnabled = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadNewGame()
    {
        SceneManager.LoadScene("Level1");
        PlayerPrefs.SetInt("HardModeEnabled", 0);
    }
    public void LoadNewHardMode()
    {
        PlayerPrefs.SetInt("HardModeEnabled", hardModeEnabled);
        SceneManager.LoadScene("Level1");
    }
    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
