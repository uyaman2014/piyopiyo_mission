<<<<<<< HEAD:Assets/Bike.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bike : MonoBehaviour, SampleInterface
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
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bike : MonoBehaviour
{/// <summary>
 ///•Ï”0.05‚ğAfloat•û‚Åì¬‚µ‚½move‚É“ü‚ê‚é
 /// </summary>
    float move = 0.05f;
    public GameObject[] prefabs
        = new GameObject[4];
    // Start is called before the first frame update
    /*void Start()
    {
        
    }*/

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += move;
        if (pos.x < -2.5f)
        {
            move = 0.05f;
        }
        if (pos.x > 2.5f)
        {
            move = -0.05f;
        }
        transform.position = pos;


    }
}
>>>>>>> develop:Assets/hayashi/Bike.cs
