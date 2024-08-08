using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;
    SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        sprite=GetComponent<SpriteRenderer>();
        animator=GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {      
        Walk();
        Jump();
    }

    void Walk()
    {
        animator.SetFloat("Speed",Mathf.Abs(rb.velocity.x));
        if(rb.velocity.x!=0)
        {
            transform.localScale= rb.velocity.x>0 ? new Vector3(1,1,1) : new Vector3(-1,1,1);
        }   
    }

    void Jump()
    {
        animator.SetFloat("Jump",rb.velocity.y);
    }
    
}
