using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public float jumpHeight;
    Rigidbody2D rb;
    public bool isDoubleJump=false;

    public bool isWallSliding=false;
    bool isWallJumping=false;
    float horizontal;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform wallCheck;
    [SerializeField] LayerMask wallLayer;

    [SerializeField] float wallJumpDuration;

    [SerializeField] float jumpForce;

    public bool isWall,isGround;

    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Move();
        WallSlide();
        WallJump();
        isWall=IsWall();
        isGround=IsGround();
    }

    bool IsWall()
    {
    
        return Physics2D.OverlapCircle(wallCheck.position,0.4f,wallLayer);
    }

    bool IsGround()
    {
       if(Physics2D.OverlapCircle(groundCheck.position,0.2f,groundLayer) || Physics2D.OverlapCircle(groundCheck.position,0.2f,wallLayer))
       {
            return true;
       }
       else
       {
        return false;
       }
         
    }

    void WallJump()
    {
        if(isWallSliding)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                isWallJumping=true;
            }

            if(isWallJumping)
            {
                
                    rb.velocity=new Vector2(-transform.localScale.x *jumpForce,jumpHeight);
                    isWallSliding=false;
                    Invoke("StopWallJump",wallJumpDuration);
                
            }
        }
    }

    void StopWallJump()
    {
        isWallJumping=false;
    }
    void WallSlide()
    {
        if(!IsGround() && IsWall() && horizontal!=0 )
        {
            isWallSliding=true;
            
            rb.velocity=new Vector2(rb.velocity.x,-3f);
            
        }
        else
        {
            isWallSliding=false;
        }

        if(rb.velocity.y<0)
        {
            isDoubleJump=false;
        }
    }
    void Move()
    {
        
        if(!isWallJumping)
        {
                horizontal = Input.GetAxis("Horizontal");
                rb.velocity=new Vector2(horizontal*speed,rb.velocity.y);
        }

        if(Input.GetKeyDown(KeyCode.Space) && IsGround() )
            {
                rb.velocity=new Vector2(rb.velocity.x,jumpHeight);
                isDoubleJump=false;
            }
            else if(Input.GetKeyDown(KeyCode.Space) && rb.velocity.y !=0 && !isDoubleJump)
            {
                rb.velocity=new Vector2(rb.velocity.x,jumpHeight/1.2f);
                isDoubleJump=true;
            }
           
        

        
        
    }
}
