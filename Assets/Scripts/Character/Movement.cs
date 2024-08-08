using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public float jumpHeight;
    Rigidbody2D rb;
    float horizontal;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] bool canMove;
    [SerializeField] bool canJump;

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
        
        
        isGround=IsGround();
    }

   

    bool IsGround()
    {
      return Physics2D.OverlapCircle(groundCheck.position,0.25f,groundLayer);
       
         
    }

    
    void Move()
    {
        if(canMove)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            rb.velocity=new Vector2(horizontal*speed,rb.velocity.y);
        }
           
        if(canJump)
        {
            if(Input.GetKeyDown(KeyCode.Space) && IsGround() )
            {
                rb.velocity=new Vector2(rb.velocity.x,jumpHeight); 
            }
        }
    }
       
}
