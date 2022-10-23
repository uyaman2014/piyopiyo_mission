using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject OyaObject;
    [SerializeField]
    private HinaSpawner HinaSpawner;
    // Start is called before the first frame update
    void Start()
    {
        var cam = Camera.main;
        Camera.main.gameObject.AddComponent<MainCameraManager>();
        CharacterManager.ResetObjects();
        CharacterManager.OyaObject = GameObject.Instantiate(OyaObject, Vector3.zero, Quaternion.identity);
        HinaSpawner.SpawnHina();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
