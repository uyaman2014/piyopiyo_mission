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
    [SerializeField]
    private string SpawnPointTagName;

    public GameObject[] SpawnPoints;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SpawnHina()
    {
        SpawnPoints = GameObject.FindGameObjectsWithTag(SpawnPointTagName);
        GameObject hina;
        for (int i = 0; i < MaxHinaCount; i++)
        {
            if (SpawnPoints.Length > 0)
            {
                var spawn = SpawnPoints[Random.Range(0, SpawnPoints.Length)];
                hina = GameObject.Instantiate(HinaPrefab, spawn.transform.position, spawn.transform.rotation);
            }
            else
                hina = GameObject.Instantiate(HinaPrefab, transform.position, Quaternion.identity);
            hina.GetComponent<HinaManager>().Spawner = this;
            CharacterManager.HinaObjects.Add(hina);
        }
    }

    public GameObject GetRandomSpawnPoint()
    {
        var spawn = SpawnPoints[Random.Range(0, SpawnPoints.Length)];
        if (spawn)
            return spawn;
        else
            return null;
    }
}
