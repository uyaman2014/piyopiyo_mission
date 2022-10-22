using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]

public class Dog : MonoBehaviour
{
    [SerializeField]
    private Sprite Dog1;
    [SerializeField]
    private Sprite Dog2;
    private SpriteRenderer Renderer;
    // Start is called before the first frame update
    void Start()
    {
        Renderer = GetComponent<SpriteRenderer>();
        Renderer.sprite = Dog1;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("kamo"))
        {
            Renderer.sprite = Dog2;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("kamo"))
        {
            Renderer.sprite = Dog1;
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
