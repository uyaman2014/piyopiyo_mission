using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CarSqript : MonoBehaviour
{
    [SerializeField]
    private Vector2 Velocity;

    public Vector2 VectorFunc()
    {
        return Vector2.zero;
    }

    // Start is called before the first frame update
    void Start()
    {

        GetComponent<Rigidbody2D>().velocity = Vector2.left;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

