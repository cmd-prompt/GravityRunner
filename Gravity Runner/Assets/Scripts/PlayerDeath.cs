using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using JetBrains.Annotations;

public class PlayerDeath : MonoBehaviour
{   
    public bool playerHasDied = false;
    [SerializeField] OxygenBar oxygenBar;
    [SerializeField] float oxygenTankValue = 5f;
    
    [Header("Player Position")]
    public Transform player;
    public float initialOffset;

    [Header ("Score Status")]
    public float finalScore = 0f;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI finalText;


    void Awake()
    {
        finalText = GameObject.Find("Final Score Text").GetComponent<TextMeshProUGUI>();
        initialOffset = player.transform.position.x;
    }

    void Update()
    {

    }
    
    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Obstacle")
        {
            target.gameObject.SetActive(false);
            PlayerDied();
        }
        else if(target.tag == "OxygenTank")
        {
            target.gameObject.SetActive(false);
            oxygenBar.oxygenValue += oxygenTankValue;
        }
    }

    public void PlayerDied()
    {
        finalScore = player.transform.position.x - initialOffset;
        finalText.text = finalScore.ToString("0");
        // transform.position = new Vector3(0, 1000, 0);
        GameObject.Find("Player").SetActive(false);
        playerHasDied = true; 
        this.enabled = false;
        oxygenBar.enabled = false;     
    }
}
