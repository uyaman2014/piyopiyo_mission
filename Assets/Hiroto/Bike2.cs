using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bike2 : MonoBehaviour
{
   [SerializeField]
   private Vector2 velocity;
    public enum Type
    {
        boybike,gialbike
    }
    public Type type;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = velocity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
