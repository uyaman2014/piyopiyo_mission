using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using keigo.Scripts.Common;
using Manager;

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
    [SerializeField]
    float NoHitTimeDuration = 3f;
    [SerializeField]
    float BoostRatio = 10f;
    [SerializeField]
    float BoostDuration = 3f;
    // Start is called before the first frame update
    
    void Start()
    {
        positions = new Queue<Vector3>(QueueCount);
        TargetPoint = transform.position;
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
            if (!oyaManager.RefecenceObject)
                oyaManager.RefecenceObject = this.gameObject;
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

    public void OnMovingObstacled(float scattered)
    {
        TargetPoint = transform.position;
        if(ReferenceObject)
        {
            ReferenceObject.GetComponent<HinaManager>().OnMovingObstacled(scattered);
        }
        Scatter(scattered);
    }

    public void OnGoal()
    {
        if (TargetObject)
        {
            var hinaManager = TargetObject.GetComponent<HinaManager>();
            if(hinaManager)
                hinaManager.OnGoal();
        }
        ScoreManager.Instance.IncreaseScore(1);
        ResetPosition();
    }

    void ResetPosition()
    {
        var spawn= Spawner.GetRandomSpawnPoint();
        transform.position = spawn.transform.position;
        TargetPoint = transform.position;
        positions.Clear();
        targetrb2d = null;
        TargetObject = null;
        ReferenceObject = null;
        if (oyaManager.RefecenceObject == this.gameObject)
            oyaManager.RefecenceObject = null;
    }

    void Scatter(float ratio)
    {
        TargetPoint = transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * ratio;
        GetComponent<HinaMovementComponent>().Boost(BoostRatio, BoostDuration);
        positions.Clear();
        targetrb2d = null;
        TargetObject = null;
        ReferenceObject = null;
        if (oyaManager.RefecenceObject == this.gameObject)
            oyaManager.RefecenceObject = null;
        StartCoroutine(DisableCollisionTimer(NoHitTimeDuration));
    }

    IEnumerator DisableCollisionTimer(float duration)
    {
        var col = GetComponent<Collider2D>();
        col.GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(duration);
        col.GetComponent<Collider>().enabled = true;
    }
}
