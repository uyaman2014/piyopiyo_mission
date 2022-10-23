using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGoal : MonoBehaviour
{
    [SerializeField]
    private string GoalTagName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == GoalTagName)
        {
            var oyaManager = GetComponent<OyaManager>();
            if (oyaManager.CurrentTargetObject != this.gameObject && oyaManager.CurrentTargetObject)
            {
                oyaManager.CurrentTargetObject.GetComponent<HinaManager>().OnGoal();
                oyaManager.CurrentTargetObject = this.gameObject;
            }
        }
    }
}
