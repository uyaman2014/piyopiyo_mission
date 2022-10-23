using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mizukusa : MonoBehaviour
{
    [SerializeField]
    private Sprite Mizukusa1;
    private SpriteRenderer Renderer;
    void Start()
    {
        Renderer = GetComponent<SpriteRenderer>();
        Renderer.sprite = Mizukusa1;
    }
     void OnTriggerEnter(Collider other)
    {
        
            
        
        
    }
    // Update is called once per frame
    void Update()
    {
    //    other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0,10), ForceMode.VelocityChange);
    }
}
