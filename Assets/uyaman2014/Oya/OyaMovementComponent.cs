using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyaMovementComponent : CharacterMovementBase
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void FixedUpdate()
    {
        MovePoint = MovePointManager.MovePoint;
        base.FixedUpdate();
    }
}
