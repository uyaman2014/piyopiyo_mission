using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CarSqript : MonoBehaviour
{
    public enum Type
    {
        whitecar,blecar,redcar
    }
    public Type type;
    [SerializeField]
    private Vector2 Velocity;

    public Vector2 VectorFunc()
    {
        return Vector2.zero;
    }

    
    void Start()
    {

       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

