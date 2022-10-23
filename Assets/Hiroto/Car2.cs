using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car2 : MonoBehaviour
{
    [SerializeField]
    private Vector2 velocity;
    public enum Type
    {
        WC,BC,RC,torakku1,torakku2,torakku3,torakku4
    }
    public Type type;
   
  
    // Start is called before the first frame update
    /*public Vector2 VectorFunk()
    {
        return Vector2.zero;
    }*/
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = velocity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
