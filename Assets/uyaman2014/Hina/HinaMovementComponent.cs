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
        //MovePoint = hinaManager.TargetObject.transform.position;
        MovePoint = hinaManager.TargetPoint;
        base.FixedUpdate();
    }
    public void Boost(float ratio, float time)
    {
        StartCoroutine(BoostImplement(ratio, time));
    }
    private IEnumerator BoostImplement(float ratio, float time)
    {
        var defaultSpeed = MoveSpeed;
        MoveSpeed = ratio;
        yield return new WaitForSeconds(time);
        MoveSpeed = defaultSpeed;
    }
}
