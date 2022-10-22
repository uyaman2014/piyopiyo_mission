using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCar : MonoBehaviour
{
    private GameObject Car;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn()
    {
        while(true)
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
            Destroy(collision.gameObject);
        }
       
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
