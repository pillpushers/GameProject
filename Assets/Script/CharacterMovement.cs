using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float Speed;//水平移动速度
    public float jumpHigh;//跳跃高度
    public float fallMutiplier;//下落加速度
    public float lowMutiplier;//上升时的加速度
    public float FaceDirection;  //面部朝向
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()//每帧刷新
    {
        Movement();
        BetterJump();
    }
    
    void Movement(){
        float HorizontalMove; //水平移动
        
        HorizontalMove = Input.GetAxis("Horizontal"); //获取水平输入
        FaceDirection = Input.GetAxisRaw("Horizontal");//获取角色朝向
        
        //改变水平方向移动速度
        if(HorizontalMove != 0) 
        rb.velocity = new Vector2(HorizontalMove * Speed, rb.velocity.y);

        //改变面部朝向
        if(FaceDirection != 0){
            float ScaleX = transform.localScale.x;
            float ScaleY = transform.localScale.y;
            float ScaleZ = transform.localScale.z;
            transform.localScale = new Vector3(FaceDirection, 1, 1);
        }
    }
       //better jump
       void BetterJump(){
         //jump
       if(Input.GetButtonDown("Jump")){
           rb.velocity = new Vector2(rb.velocity.x, jumpHigh );
       }
       //better
        if(rb.velocity.y < 0){ 
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMutiplier - 1) * Time.deltaTime;
        }
        else if(rb.velocity.y >= 0 && !Input.GetButton("Jump")){
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowMutiplier - 1) * Time.deltaTime;
        }
    }

    
}
