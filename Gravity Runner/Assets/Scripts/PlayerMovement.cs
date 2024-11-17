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
    }

    IEnumerator Nambah_Kecepatan() 
    {
        while (speed < kecepatan_Maks) {
        yield return new WaitForSeconds(acceleration_time);
        speed += acceleration;
        }
    }
}
