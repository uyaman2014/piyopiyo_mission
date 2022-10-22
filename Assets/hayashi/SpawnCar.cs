using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCar : MonoBehaviour
{
    private GameObject Car;
    public GameObject[] prefabs
        = new GameObject[3];
    int curvege = 0;
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
            float y = Random.Range(-4.5f, 4.5f);
            int direction = Random.Range(0, 2);
            if (direction == 0)
            {
                Car.transform.position = new Vector3(3.0f, y, 0);
            }
            else
            {
                Car.transform.position = new Vector3(-3.0f, y, 0);
            }
            Instantiate(Car);
            yield return new WaitForSeconds(1.5f);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
       if(collision.CompareTag("karugamo"))
        {
            Instantiate(prefabs[curvege]);
            curvege++;
            curvege %= 3;
            Destroy(collision.gameObject);
        }
       
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
