using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D myBody;
    private Button jumpButton;
    private PolygonCollider2D myCharacterCollider2d;

    public Canvas pauseScreen;

    AudioPlayer audioPlayer;

    [SerializeField] private float speed = 6f;
    [SerializeField] private float acceleration = 1f;
    [SerializeField] private float acceleration_time = 3f;    
    [SerializeField] private float kecepatan_Maks = 20f;

    void Awake() 
    {
        // Syarat: Nama tombol buat karakter loncat = Jump Button
        jumpButton = GameObject.Find("Jump Button").GetComponent<Button>();
        jumpButton.onClick.AddListener (() => Jump ());
        myBody = GetComponent<Rigidbody2D>();
        myCharacterCollider2d = GetComponent<PolygonCollider2D>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void Start() 
    {
        StartCoroutine(Nambah_Kecepatan());
    }

    void Update()
    {
        Vector3 temp = transform.position;
        temp.x += speed * Time.deltaTime;
        transform.position = temp;


        // Unused Feature: if "A" is pressed, speed up the gravity

        // if(!pauseScreen.gameObject.activeInHierarchy)
        // {
        //     if(Input.GetKey(KeyCode.A))
        //     {
        //         speedUp();
        //     }
        //     else if (!Input.GetKey(KeyCode.A))
        //     {
        //         if(myBody.gravityScale == 10f)
        //         {
        //             myBody.gravityScale = 5f;
        //         }
        //         if(myBody.gravityScale == -10f)
        //         {
        //             myBody.gravityScale = -5f;
        //         }
        //     }

        // }
    }
    private void Jump() 
    {
        // Syarat: bikin floor dan ceilling di layer "Platform"
        // if (!myCharacterCollider2d.IsTouchingLayers(LayerMask.GetMask("Platform")))    
        // {
        //     return;
        // }
        myBody.gravityScale *= -1;

        Vector3 temp = transform.localScale;
        temp.y *= -1;
        transform.localScale = temp;

        Vector3 temp2 = myBody.velocity;

        if (temp.y > 0)
        {
            temp2.y = -10;
        }

        else if (temp.y < 0)
        {
            temp2.y = 10;
        }

        audioPlayer.PlayJumpClip();
        myBody.velocity = temp2;
    }

    IEnumerator Nambah_Kecepatan() 
    {
        while (speed < kecepatan_Maks) {
        yield return new WaitForSeconds(acceleration_time);
        speed += acceleration;
        }
    }

    // Unused Function for the Unused Feature
    
    // private void speedUp()
    // {
    //     if (myBody.gravityScale > 0)
    //         {
    //             if (myBody.gravityScale == 5f)
    //             {
    //                 myBody.gravityScale = 10f;
    //             }
                
    //         }
            
    //     else if (myBody.gravityScale < 0)
    //         {
    //             if (myBody.gravityScale == -5f)
    //             {
    //                 myBody.gravityScale = -10f;
    //             }
    //         }
    // }
}
