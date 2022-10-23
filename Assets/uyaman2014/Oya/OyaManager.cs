using System.Collections;
using System.Collections.Generic;
using keigo.Scripts.Common;
using UnityEngine;

public class OyaManager : MonoBehaviour
{
    public GameObject CurrentTargetObject;
    public GameObject RefecenceObject;
    [SerializeField]
    private string MovingObstacleTag = "MovingObstacle";
    // Start is called before the first frame update
    void Start()
    {
        CurrentTargetObject = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == MovingObstacleTag && RefecenceObject)
        {
            RefecenceObject.GetComponent<HinaManager>().OnMovingObstacled(collision.gameObject.GetComponent<IMovingObstacle>().Scattered);
            CurrentTargetObject = this.gameObject;
        }
    }
}
