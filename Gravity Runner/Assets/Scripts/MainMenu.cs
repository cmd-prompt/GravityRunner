using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Canvas settingsScreen;
    string difficulty = "Normal";

    void Awake()
    {
        
    }

    void Start()
    {
        settingsScreen.gameObject.SetActive(false);
    }
    public void StartGame() 
    {
        SceneManager.LoadScene(difficulty);
        Time.timeScale = 1;
    }

    public void BackToMenu() 
    {
        SceneManager.LoadScene("Starting Screen");
        Time.timeScale = 1;
    }

    public void Easy()
    {
        difficulty = "Easy";
        Debug.Log(difficulty);
    }

    public void Normal()
    {
        difficulty = "Normal";
        Debug.Log(difficulty);
    }

    public void Hard()
    {
        difficulty = "Hard";
        Debug.Log(difficulty);
    }

    public void ToSettings()
    {
        settingsScreen.gameObject.SetActive(true);
    }

    public void QuitSettings()
    {
        settingsScreen.gameObject.SetActive(false);
    }
}
