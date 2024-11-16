using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Collector : MonoBehaviour
{
    private float width = 0f;

    // Start is called before the first frame update
    void Awake()
    {
        width = GameObject.Find ("BG").GetComponent<BoxCollider2D> ().size.x;
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "BG")
        {
            Vector3 temp2 = target.transform.localScale;
            temp2.x *= -1;
            target.transform.localScale = temp2;

            Vector3 temp = target.transform.position;
            temp.x += width * 3;
            target.transform.position = temp;
        }

        if(target.tag == "Platform")
        {
            Vector3 temp = target.transform.position;
            temp.x += width * 3;
            target.transform.position = temp;
        }
    }
}