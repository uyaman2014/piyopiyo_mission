using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HinaMovementComponent : CharacterMovementBase
{
    HinaManager hinaManager;
    protected override void Start()
    {
        hinaManager = GetComponent<HinaManager>();
        base.Start();
    }
    protected override void FixedUpdate()
    {
        if (hinaManager.TargetObject)
        {
            //MovePoint = hinaManager.TargetObject.transform.position;
            MovePoint = hinaManager.TargetPoint;
        }
        else
        {
            MovePoint = this.transform.position;
        }
        base.FixedUpdate();
    }
}
