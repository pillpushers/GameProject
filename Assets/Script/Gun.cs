using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gun : MonoBehaviour
{
    public GameObject rocket;
    public float speed=20f;
  

    private CharacterMovement playerCtrl;
    private Animator anim;
    void Awake()
    {
        anim = transform.root.gameObject.GetComponent<Animator>();
        playerCtrl = transform.root.GetComponent<CharacterMovement>();
    }

    // Update is called once per frame
    void Update()
    {  
        
        if(Input.GetButtonDown("Fire1"))
        {
            GetComponent<AudioSource>().Play();//发出枪声

            if(playerCtrl.FaceDirection == true)
            {
                             
                GameObject bulletInstance = Instantiate(rocket, transform.position, Quaternion.Euler(0, 0, 0)) ;
                Rigidbody2D bi= bulletInstance.GetComponent<Rigidbody2D>();//使用刚体是子弹运动起来
                bi.velocity = new Vector2(speed, 0);//直接设置速度使刚体运动
                
            }
            else
            {
                GameObject bulletInstance = Instantiate(rocket, transform.position, Quaternion.Euler(0, 0, 180f));
                Rigidbody2D bi = bulletInstance.GetComponent<Rigidbody2D>();
                bi.velocity = new Vector2(-speed, 0);//面向左为负
                //Rigidbody2D bi = bulletInstance as Rigidbody2D;
            }
        }
        
    }
}
