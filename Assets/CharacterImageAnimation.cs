using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterImageAnimation : MonoBehaviour
{
    [SerializeField]
    private Sprite[] Sprites = new Sprite[3];
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        var vel = rb2d.velocity.normalized;
        if(vel.y > 0)
        {
            if (vel.x <= -0.85)
            {
                spriteRenderer.sprite = Sprites[0];
                spriteRenderer.flipX = false;
            }
            else if(vel.x > 0.85)
            {
                spriteRenderer.sprite = Sprites[0];
                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.sprite = Sprites[1];
                spriteRenderer.flipX = false;
            }
        }
        else
        {
            if (vel.x <= -0.85)
            {
                spriteRenderer.sprite = Sprites[0];
                spriteRenderer.flipX = false;
            }
            else if (vel.x > 0.85)
            {
                spriteRenderer.sprite = Sprites[0];
                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.sprite = Sprites[2];
                spriteRenderer.flipX = false;
            }
        }
    }
}
