using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour

{
    public Rigidbody2D rb;
    public Vector2 speed;
    public Collider2D coll;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    void Movement(){
        rb.AddForce(new Vector2(speed.x, 0));
        
    }
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Wall" ){
            speed.x *= -1;
        // rb.AddForce(new Vector2(-speed.x*2, 0));
    }
    }
}
