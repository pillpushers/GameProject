using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour

{
    public Rigidbody2D rb;
    public Vector2 speed;
    public Collider2D coll;
    public Sprite damagedEnemy;
    public Sprite deadEnemy;
    private SpriteRenderer spriteRenderer;
    public int HP = 2;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
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
    private void OnCollisionEnter2D(Collision2D collision){
       // Debug.Log(collision.gameObject.tag);

        if(collision.gameObject.tag == "Wall" ){
            
            speed.x *= -1;
            }
        // rb.AddForce(new Vector2(-speed.x*2, 0));
        else if(collision.gameObject.tag == "Weapon"){
            Hurt();
            Debug.Log("weapon");
        }
    }
    public void Hurt(){
        HP--;
        if (HP == 1 && damagedEnemy != null)
            {
                spriteRenderer.sprite = damagedEnemy;
            }
            if (HP <= 0 && deadEnemy != null)
            {
                spriteRenderer.sprite = deadEnemy;
                Death();
            }
    }
    void Death(){
        GetComponent<Collider2D>().isTrigger = true;
        Debug.Log("Dead!");
    }
}

