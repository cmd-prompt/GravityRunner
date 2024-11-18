using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenBar : MonoBehaviour
{
    [SerializeField] public float oxygenMeter = 30f;
    [SerializeField] Image timerImage;
    public float fillFraction = 1f;
    public float oxygenValue;
    [SerializeField] PlayerDeath player;

    void Start()
    {
        oxygenValue = oxygenMeter;
    }

    void Update()
    {
        UpdateTimer();
    }

    void UpdateTimer()
    {   
        oxygenValue -= Time.deltaTime;

        if(oxygenValue > oxygenMeter)
        {
            oxygenValue = oxygenMeter;
            fillFraction = oxygenValue / oxygenMeter;
        }
        else if(oxygenValue > 0)
        {
            fillFraction = oxygenValue / oxygenMeter;
        }
        else
        {
            fillFraction = 0;
            player.PlayerDied();
            this.enabled = false;
        }

        timerImage.fillAmount = fillFraction;
    }

}
