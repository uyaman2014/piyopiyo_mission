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
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTimer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnTimer()
    {
        yield return new WaitForSeconds(Random.Range(IntervalMin, IntervalMax));
        GameObject.Instantiate(HinaPrefab, transform).GetComponent<HinaManager>().Spawner = this;
    }

    public void UnLockSpawner()
    {
        StartCoroutine(SpawnTimer());
    }
}
