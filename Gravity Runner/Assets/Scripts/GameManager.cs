using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Canvas mainUI;
    Canvas endScreen;
    public PlayerDeath playerDeath;

    Canvas pauseScreen;

    public Button jumpButton;
    [SerializeField] Canvas settingScreen;

    void Awake()
    {
        mainUI = GameObject.Find("Main Canvas").GetComponent<Canvas>();
        endScreen = GameObject.Find("GameOver").GetComponent<Canvas>();
        pauseScreen = GameObject.Find("PauseScreen").GetComponent<Canvas>();
        playerDeath = GameObject.Find("Player").GetComponent<PlayerDeath>();
        
        mainUI.gameObject.SetActive(true);
        endScreen.gameObject.SetActive(false);
        pauseScreen.gameObject.SetActive(false);
    }

    void Update()
    {       
        if (playerDeath.playerHasDied == true)
        {
            mainUI.gameObject.SetActive(false);
            endScreen.gameObject.SetActive(true);
        }

        else if (playerDeath.playerHasDied == false)
        {
            if(Input.GetKeyDown (KeyCode.Escape)) 
            {
                if (!pauseScreen.gameObject.activeInHierarchy) 
                {
                    PauseGame();
                }
                else if (pauseScreen.gameObject.activeInHierarchy) 
                {
                    if(!settingScreen.gameObject.activeInHierarchy)
                    ContinueGame();
                }
            } 
        }

        if(!pauseScreen.gameObject.activeInHierarchy)
        {
            jumpButton.gameObject.SetActive(true);
        }
        else if (pauseScreen.gameObject.activeInHierarchy)
        {
            jumpButton.gameObject.SetActive(false);
        }

        
    }

    public void PauseMechanism()
    {
        if (!pauseScreen.gameObject.activeInHierarchy) 
        {
            PauseGame();
        }
        else if (pauseScreen.gameObject.activeInHierarchy) 
        {
            if(!settingScreen.gameObject.activeInHierarchy)
            ContinueGame();
        }
    }

    public void OnReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnResumeLevel()
    {
        Time.timeScale = 1;
        pauseScreen.gameObject.SetActive(false);
        jumpButton.gameObject.SetActive(true);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseScreen.gameObject.SetActive(true);
        
    } 
    public void ContinueGame()
    {
        Time.timeScale = 1;
        pauseScreen.gameObject.SetActive(false);
    }
}
