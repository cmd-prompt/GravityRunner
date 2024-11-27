using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Canvas settingsScreen;
    [SerializeField] GameObject easyPNG;
    [SerializeField] GameObject normalPNG;
    [SerializeField] GameObject hardPNG;
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
        if (normalPNG.gameObject.activeInHierarchy)
        {
            normalPNG.gameObject.SetActive(false);
        }

        if (!easyPNG.gameObject.activeInHierarchy)
        {
            easyPNG.gameObject.SetActive(true);
        }

        if (hardPNG.gameObject.activeInHierarchy)
        {
            hardPNG.gameObject.SetActive(false);
        }
    }

    public void Normal()
    {
        difficulty = "Normal";
        if (!normalPNG.gameObject.activeInHierarchy)
        {
            normalPNG.gameObject.SetActive(true);
        }

        if (easyPNG.gameObject.activeInHierarchy)
        {
            easyPNG.gameObject.SetActive(false);
        }

        if (hardPNG.gameObject.activeInHierarchy)
        {
            hardPNG.gameObject.SetActive(false);
        }
    }

    public void Hard()
    {
        difficulty = "Hard";
        if (normalPNG.gameObject.activeInHierarchy)
        {
            normalPNG.gameObject.SetActive(false);
        }

        if (easyPNG.gameObject.activeInHierarchy)
        {
            easyPNG.gameObject.SetActive(false);
        }

        if (!hardPNG.gameObject.activeInHierarchy)
        {
            hardPNG.gameObject.SetActive(true);
        }
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
