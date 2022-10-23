using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBike1 : MonoBehaviour
{
    private GameObject Bike;
   // int curvege = 0;
    /*var nums = new int[] { 0, 1, 2, 3, 4, 5, 6 };
    var randomNum =
       nums[Random.Range(0, nums.Length)];*/
    public GameObject[] prefabs
        = new GameObject[7];

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());

    }
    IEnumerator Spawn()
    {
        while (true)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.left;
            float y = Random.Range(-4.5f, -4.5f);
            int direetion = Random.Range(0, 2);
            if (direetion == 0)
            {
                Bike.transform.position = new Vector3(3.0f, y, 0);
            }
            else
            {
                Bike.transform.position = new Vector3(-3.0f, y, 0);
            }
            Instantiate(Bike);
            yield return new WaitForSeconds(Random.Range(1, 3));

        }

    }
    // Update is called once per frame
    void Update()
    {

    }
}
