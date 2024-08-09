using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public float jumpHeight;
    public float boundForce;
    Rigidbody2D rb;
    float horizontal;
    [SerializeField] bool canMove;
    [SerializeField] bool canJump;
    [SerializeField] bool canMoveLeft;
    [SerializeField] bool canMoveRight;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       Move();
       if(horizontal ==0)
       {
           rb.velocity = new Vector2(0, rb.velocity.y);
       }
    }
    
    void Move()
    {
        if(canMove)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            if(canMoveLeft && horizontal<0 || canMoveRight && horizontal > 0)
            {
                rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
            }
        }
           
        if(canJump)
        {
            if(Input.GetKeyDown(KeyCode.Space) && rb.velocity.y==0)
            {
                rb.velocity=new Vector2(rb.velocity.x,jumpHeight); 
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bounce")
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, boundForce), ForceMode2D.Impulse);
    }
}
