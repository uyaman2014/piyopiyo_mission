using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SpawnerBike : MonoBehaviour
{
    
    [SerializeField]
    private Vector2 Velocity;

    public Vector2 VectorFunc()
    {
        return Vector2.zero;
    }
    
    public GameObject[] prefabs
        = new GameObject[2];
    int curvege = 0;

    void Start()
    {


    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("karugamo"))
        {
            Instantiate(prefabs[curvege]);
            curvege++;
            curvege %= 2;
            Destroy(collision.gameObject);
        }

    }
    // Update is called once per frame
    void Update()
    {

    }
}


