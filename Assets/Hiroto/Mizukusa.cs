using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mizukusa : MonoBehaviour
{
    
    void Start()
    {
        
    }
    void OnCollisionEnter(Collision2D col)
    {
        if (col.gameObject.tag == "kamo")
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
