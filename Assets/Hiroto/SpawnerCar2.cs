using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCar2 : MonoBehaviour
{
    /*int curvege=0;
    var nums = new int[] { 0, 1, 2, 3, 4, 5, 6 };
    var randomNum =
       nums[Random.Range(0, nums.Length)];*/
    public GameObject[] prefabs
        = new GameObject[7];
    public Vector2 MoveVelocity;
    public float[] IntervalRange = new float[2];
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn()
    {
        while (true)
        {
            var car = GameObject.Instantiate(prefabs[Random.Range(0, prefabs.Length)], transform.position, Quaternion.identity);
            if (MoveVelocity.x > 0)
                car.transform.localScale = new Vector3(-car.transform.localScale.x, car.transform.localScale.y, car.transform.localScale.z);
            car.GetComponent<Rigidbody2D>().velocity = MoveVelocity;
            yield return new WaitForSeconds(Random.Range(IntervalRange[0], IntervalRange[1]));
        }
    }
    
    void Update()
    {

    }
}
