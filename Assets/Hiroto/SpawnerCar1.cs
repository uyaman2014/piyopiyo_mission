using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCar1 : MonoBehaviour
{
    private GameObject Car2;
    public GameObject[] prefabs
        = new GameObject[8];
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
            float y = Random.Range(-4.5f, -4.5f);
            int direetion = Random.Range(0, 2);
            if (direetion == 0)
            {
                Car2.transform.position = new Vector3(3.0f, y, 0);
            }
            else
            {
                Car2.transform.position = new Vector3(-3.0f, y, 0);
            }
            Instantiate(Car2);
            yield return new WaitForSeconds(Random.Range(1,3));
            
        }
           
    }
    
    /*private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("kamo"))
        {
            Instantiate(prefabs[curvege]);
            curvege++;
            curvege %= 7;
            Destroy(collision.gameObject);
        }
    }*/
    // Update is called once per frame
    void Update()
    {
        
    }
}
