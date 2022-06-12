using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject explosion;
    public float rocketLifeTime = 1;
    void Start()
    {
        Destroy(gameObject, rocketLifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "Player")
        {
            float rotation = Random.Range(0, 360);
            Instantiate(explosion, transform.position,
                        Quaternion.Euler(0, 0, rotation));
            Destroy(gameObject);
        }
    }
    
}
