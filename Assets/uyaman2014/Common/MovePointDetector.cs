using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MovePointManager
{
    public static Vector3 MovePoint;
}

public class MovePointDetector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MovePointManager.MovePoint = Vector3.zero;
    }

    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            var pos = Input.mousePosition;
            pos.z = -Camera.main.transform.position.z;
            MovePointManager.MovePoint = Camera.main.ScreenToWorldPoint(pos);
        }
    }
}
