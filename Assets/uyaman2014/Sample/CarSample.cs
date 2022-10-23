using System.Collections;
using System.Collections.Generic;
using keigo.Scripts.Common;
using UnityEngine;

public class CarSample : MonoBehaviour, IMovingObstacle
{
    [SerializeField]
    private float ScatterScale;
    public float Scattered => ScatterScale;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
