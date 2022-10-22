using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HinaSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject HinaPrefab;
    [SerializeField]
    private float IntervalMin;
    [SerializeField]
    private float IntervalMax;
    [SerializeField]
    private int MaxHinaCount;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < MaxHinaCount; i++)
        {
            GameObject.Instantiate(HinaPrefab, transform).GetComponent<HinaManager>().Spawner = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
