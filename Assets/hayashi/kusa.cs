using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kusa : MonoBehaviour
{
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    /*private void OnCollisionEnter(Collision2D col)
    {
       
    }*/
    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpeedUp()
    {
        speed = 0.1f;
        yield return new WaitForSeconds(3.0f);
        speed = 0.01f;
    }

}
