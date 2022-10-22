using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSample : MonoBehaviour, SampleInterface
{
    public float FloatFunc()
    {
        return 100;
    }

    public int IntFunc()
    {
        return -1;
    }

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
