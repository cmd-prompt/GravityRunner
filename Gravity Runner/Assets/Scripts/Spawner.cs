using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{    
    [SerializeField] private GameObject[] items;
    private float minY = -10.5f , maxY = 10.5f;
    [SerializeField] private int minTime = 1 , maxTime = 2;
    [SerializeField] private int waktu_awal_spawn;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnItems(waktu_awal_spawn));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnItems(float time)
    {
        yield return new WaitForSeconds (time);
        Vector3 temp = new Vector3 (transform.position.x, Random.Range(minY, maxY), 0);
        Instantiate (items[Random.Range(0, items.Length)], temp, Quaternion.identity);
        StartCoroutine (SpawnItems(Random.Range(minTime, maxTime)));
    }
}
