using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_2 : MonoBehaviour
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
        Vector2 Speed = new Vector2(speed.x, rb.velocity.y);
        rb.velocity = Speed;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall" ){
            speed.x *= -1;
            }
        else if(collision.gameObject.tag == "Weapon"){
        Death();
        }
    }
    public void Death(){
        GetComponent<Collider2D>().isTrigger = true;
        Debug.Log("Death");
    }
}
