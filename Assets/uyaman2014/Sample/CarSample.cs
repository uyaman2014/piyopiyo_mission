using System.Collections;
using System.Collections.Generic;
using keigo.Scripts.Common;
using UnityEngine;

public class CarSample : MonoBehaviour, IMovingObstacle
{
    [SerializeField]
    private Vector2 MoveDirection;

    public float Scattered => 10;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = MoveDirection;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
