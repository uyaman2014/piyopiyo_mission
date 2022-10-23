using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mizukusa : MonoBehaviour
{
    private float speed;
    [SerializeField]
    private Sprite Mizukusa1;
    private SpriteRenderer Renderer;
    void Start()
    {
        Renderer = GetComponent<SpriteRenderer>();
        Renderer.sprite = Mizukusa1;
    }
     
    // Update is called once per frame
    void Update()
    {
    //    other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0,10), ForceMode.VelocityChange);
    }
    IEnumerator SpeedUp()
    {
        speed = 0.1f;
        yield return new WaitForSeconds(5.0f);
        speed = 0.01f;
    }
}
