using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using keigo.Scripts.Common;

public class HinaManager : MonoBehaviour
{
    public GameObject TargetObject;
    public GameObject ReferenceObject;
    public Vector3 TargetPoint;
    public HinaSpawner Spawner;
    
    private OyaManager oyaManager;
    private Rigidbody2D targetrb2d;
    private Queue<Vector3> positions;

    [SerializeField]
    int QueueCount;
    [SerializeField]
    string ParentTagName;
    [SerializeField]
    string MovingObstacleTagName;
    // Start is called before the first frame update
    
    void Start()
    {
        positions = new Queue<Vector3>(QueueCount);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (!targetrb2d || !TargetObject)
            return;
        if (positions.Count == QueueCount)
        {
            positions.TryDequeue(out TargetPoint);
        }
        if (targetrb2d.velocity != Vector2.zero)
            positions.Enqueue(TargetObject.transform.position);
        if (TargetObject.GetComponent<OyaManager>())
            return;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ParentTagName)
        {
            if (TargetObject)
                return;
            oyaManager = collision.gameObject.GetComponent<OyaManager>();
            if (!oyaManager)
                return;
            TargetObject = oyaManager.CurrentTargetObject;
            oyaManager.CurrentTargetObject = this.gameObject;
            TargetPoint = TargetObject.transform.position;
            targetrb2d = TargetObject.GetComponent<Rigidbody2D>();
            var hinaManager = TargetObject.GetComponent<HinaManager>();
            if(hinaManager)
            {
                hinaManager.ReferenceObject = this.gameObject;
            }
        }
        else if (collision.tag == MovingObstacleTagName)
        {
            var imo = collision.GetComponent<IMovingObstacle>();
            if (imo == null)
                return;
            if(TargetObject)
                oyaManager.CurrentTargetObject = TargetObject;
            OnMovingObstacled(imo.Scattered);
        }
    }

    void OnMovingObstacled(float scattered)
    {
        TargetObject = null;
        transform.position = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * scattered;
        TargetPoint = transform.position;
        if(ReferenceObject)
        {
            ReferenceObject.GetComponent<HinaManager>().OnMovingObstacled(scattered);
        }
        ReferenceObject = null;
    }

    public void OnGoal()
    {
        transform.position = new Vector3(Random.Range(-5f, 5f), Random.Range(-3f, 3f));
        TargetPoint = transform.position;
        if (TargetObject)
        {
            var hinaManager = TargetObject.GetComponent<HinaManager>();
            if(hinaManager)
                hinaManager.OnGoal();
        }
        ReferenceObject = null;
        TargetObject = null;
    }
}
