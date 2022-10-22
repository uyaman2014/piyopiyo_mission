using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementBase : MonoBehaviour
{
    public float MoveSpeed;

    public float MinMoveDistance;

    protected Vector3 MovePoint;

    private float sqrMinMoveDistance;
    private Rigidbody2D rigidbody2d;
    // Start is called before the first frame update
    virtual protected void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        sqrMinMoveDistance = Mathf.Pow(MinMoveDistance, 2);
    }

    virtual protected void FixedUpdate()
    {
        var diff = MovePoint - transform.position;
        var clampedMoveSpeed = Mathf.Clamp(MoveSpeed, 0, diff.magnitude / Time.deltaTime);
        if ((transform.position - MovePoint).sqrMagnitude > sqrMinMoveDistance)
        {
            rigidbody2d.velocity = (diff).normalized * clampedMoveSpeed;
        }
        else
        {
            rigidbody2d.velocity = Vector3.zero;
        }
    }
}
