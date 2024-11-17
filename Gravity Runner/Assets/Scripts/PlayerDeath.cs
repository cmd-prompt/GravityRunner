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
    public Transform player;
    public float finalScore = 0f;
    public TextMeshProUGUI finalText;
    public float initialOffset;
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
            finalScore = player.transform.position.x - initialOffset;
            finalText.text = "Final Score: " + finalScore.ToString("0");
            // transform.position = new Vector3(0, 1000, 0);
            GameObject.Find("Player").SetActive(false);
            target.gameObject.SetActive(false);
            playerHasDied = true;
        }
    }

}
