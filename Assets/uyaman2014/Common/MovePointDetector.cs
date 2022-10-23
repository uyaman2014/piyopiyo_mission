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
    [SerializeField]
    private GameObject TargetPointer;
    [SerializeField]
    private float VisibleTime;
    private Coroutine corutine;
    [SerializeField]
    List<Vector2> MapSize;
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
            MovePointManager.MovePoint = new Vector2(Mathf.Clamp(MovePointManager.MovePoint.x, MapSize[0].x, MapSize[1].x), Mathf.Clamp(MovePointManager.MovePoint.y, MapSize[1].y, MapSize[0].y));
            if(corutine != null)
                StopCoroutine(corutine);
            corutine = StartCoroutine(PointerRenderTimer(MovePointManager.MovePoint, VisibleTime));
        }
    }

    IEnumerator PointerRenderTimer(Vector3 position, float time)
    {
        TargetPointer.SetActive(true);
        TargetPointer.transform.position = position;
        yield return new WaitForSeconds(time);
        TargetPointer.SetActive(false);
    }
}
