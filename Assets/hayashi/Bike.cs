using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bike : MonoBehaviour
{/// <summary>
 ///�ϐ�0.05���Afloat���ō쐬����move�ɓ����
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
