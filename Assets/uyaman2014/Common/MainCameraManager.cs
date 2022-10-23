using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraManager : MonoBehaviour
{
    private float defaultCameraSize;
    private float targetCameraSize;
    private float currentCameraSize;
    [SerializeField]
    private float LerpT = 0.001f;
    // Start is called before the first frame update
    void Start()
    {
        defaultCameraSize = Camera.main.orthographicSize;
        targetCameraSize = defaultCameraSize;
        currentCameraSize = defaultCameraSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (!CharacterManager.OyaObject)
            return;
        var pos = CharacterManager.OyaObject.transform.position;
        pos.z = gameObject.transform.position.z;
        gameObject.transform.position = pos;
        float max = 0, min = 0;
        foreach (var hina in CharacterManager.HinaObjects)
        {
            if (hina.GetComponent<HinaManager>().TargetObject == null)
                continue;
            var point = Camera.main.WorldToViewportPoint(hina.transform.position);
            max = Mathf.Max(point.x, point.y, max);
            min = Mathf.Min(point.x, point.y, min);
        }
        
        max = Mathf.Max(max, 1 - min);
        if (max > 1)
            targetCameraSize = Camera.main.orthographicSize * max;
        else
            targetCameraSize = defaultCameraSize;

        if (targetCameraSize > currentCameraSize)
            currentCameraSize = targetCameraSize;
        else
            currentCameraSize = Mathf.Lerp(currentCameraSize, targetCameraSize, LerpT);

        Camera.main.orthographicSize = currentCameraSize;
    }
}
