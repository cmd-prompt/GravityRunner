using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    Canvas settingsScreen;

    void Awake()
    {
        settingsScreen = GameObject.Find("Settings Screen").GetComponent<Canvas>();
        settingsScreen.gameObject.SetActive(false);
    }

    public void StartGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BackToMenu() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
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
