using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
   [Header("Jump")]
    [SerializeField] AudioClip gravityClip;
    [SerializeField] [Range(0f, 100f)] float gravityVolume = 100f;

    [Header("Death")]
    [SerializeField] AudioClip deathClip;
    [SerializeField] [Range(0f, 100f)] float deathVolume = 100f;

    [Header("Oxygen")]
    [SerializeField] AudioClip oxygenClip;
    [SerializeField] [Range(0f, 100f)] float oxygenVolume = 100f;


    public void PlayJumpClip()
    {
        PlayClip(gravityClip, gravityVolume);
    }
    
    public void PlayDeathClip()
    {
        PlayClip(deathClip, deathVolume);
    }

    public void PlayOxygenClip()
    {
        PlayClip(oxygenClip, oxygenVolume);
    }

    void PlayClip(AudioClip clip, float volume)
    {
        if(clip != null)
        {
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
        }
    }

}
