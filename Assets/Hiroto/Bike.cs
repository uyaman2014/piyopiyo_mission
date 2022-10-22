
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Bike : MonoBehaviour
{

    [SerializeField]
    private Vector2 velocity;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = velocity;
    }
    void Update()
    {

    }

}

