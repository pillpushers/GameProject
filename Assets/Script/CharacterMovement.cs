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
    public bool FaceDirection = false;  //面部朝向
    public AudioClip[] jumpClips;//音频数组
    //private bool grounded = false;
    //private Transform groundCheak;//射线检测
    public Animator anim;
    public Collider2D coll;
    public LayerMask ground;

    // Start is called before the first frame update

    void Start(){
        //groundCheak = transform.Find("groundCheak");
        // anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()//每帧刷新
    {

        Movement();
        BetterJump();
        SwithAnim();
        // grounded = Physics2D.Linecast(transform.position,groundCheak.position,1 << LayerMask.NameToLayer("Ground"));
        //Debug.DrawLine(transform.position,groundCheak.position,Color.red,1f);
    }
    
    void Movement(){
        float HorizontalMove; //水平移动
        
        HorizontalMove = Input.GetAxis("Horizontal"); //获取水平输入
        
        if(Input.GetAxisRaw("Horizontal") > 0) //获取角色朝向
        {
            FaceDirection = true;
        }
        else if(Input.GetAxisRaw("Horizontal") < 0 ){
            FaceDirection = false;
        }
        
        //改变水平方向移动速度
        if(HorizontalMove != 0) {
        rb.velocity = new Vector2(HorizontalMove * Speed, rb.velocity.y);
        anim.SetFloat("running", Mathf.Abs(rb.velocity.x));
        }
        //改变面部朝向
        if(FaceDirection == true){
            // float ScaleX = transform.localScale.x;
            // float ScaleY = transform.localScale.y;
            // float ScaleZ = transform.localScale.z;
            transform.localScale = new Vector3(1, 1, 1);

        }
        else{
             transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    //better jump
    void BetterJump(){
    //jump
    if(Input.GetButtonDown("Jump")){
        //随机进行音频片段的播放
        int i = Random.Range(0,jumpClips.Length);
        AudioSource.PlayClipAtPoint (jumpClips[i],transform.position);

        rb.velocity = new Vector2(rb.velocity.x, jumpHigh );
        anim.SetBool("jumping", true);
    }
    //better
    if(rb.velocity.y < 0){ 
        rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMutiplier - 1) * Time.deltaTime;
    }
    else if(rb.velocity.y >= 0 && !Input.GetButton("Jump")){
        rb.velocity += Vector2.up * Physics2D.gravity.y * (lowMutiplier - 1) * Time.deltaTime;
    }
    }   
   void SwithAnim(){
        anim.SetBool("idling", false);
        if(anim.GetBool("jumping")){
            if(rb.velocity.y < 0){
            anim.SetBool("jumping", false);
            anim.SetBool("falling", true);
            }
        }
        else if(coll.IsTouchingLayers(ground)){
            anim.SetBool("falling", false);
            anim.SetBool("idling", true);
        }
    
    }
}

