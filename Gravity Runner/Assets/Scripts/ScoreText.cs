using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{   
    public TextMeshProUGUI scoreText;
    public Transform player;
    public float initialOffset = 0;
    
    void Awake()
    {
        initialOffset = player.transform.position.x;
        scoreText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {   
        float score = player.transform.position.x - initialOffset;
        scoreText.text = score.ToString("0");
    }
}
