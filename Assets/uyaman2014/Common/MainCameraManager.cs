using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!CharacterManager.OyaObject)
            return;
        var pos = CharacterManager.OyaObject.transform.position;
        pos.z = gameObject.transform.position.z;
        gameObject.transform.position = pos;
    }
}
