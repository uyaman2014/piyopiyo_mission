using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HinaManager : MonoBehaviour
{
    public GameObject TargetObject;
    public Vector3 TargetPoint;
    public float MinMoveLength;
    public HinaSpawner Spawner;
    
    private Rigidbody2D targetrb2d;
    private bool isTrackingTarget;
    private Queue<Vector3> positions;

    [SerializeField]
    int queueCount;
    // Start is called before the first frame update
    void Start()
    {
        positions = new Queue<Vector3>(queueCount);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (positions.Count == queueCount)
        {
            positions.TryDequeue(out TargetPoint);
        }
        if (!targetrb2d)
            return;
        if (targetrb2d.velocity != Vector2.zero)
            positions.Enqueue(TargetObject.transform.position);
        if (TargetObject.GetComponent<OyaManager>())
            return;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isTrackingTarget) return;
        var oyaManager = collision.gameObject.GetComponent<OyaManager>();
        if (oyaManager)
        {
            TargetObject = oyaManager.CurrentTargetObject;
            oyaManager.CurrentTargetObject = this.gameObject;
            isTrackingTarget = true;
            TargetPoint = TargetObject.transform.position;
            targetrb2d = TargetObject.GetComponent<Rigidbody2D>();
            Spawner.UnLockSpawner();
        }
    }
}
