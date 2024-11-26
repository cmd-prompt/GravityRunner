using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovementNormal : MonoBehaviour
{
    [SerializeField] public float obstacleSpeed = -5f;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = transform.position;
        temp.x += obstacleSpeed * Time.deltaTime;
        transform.position = temp;
    }
}
