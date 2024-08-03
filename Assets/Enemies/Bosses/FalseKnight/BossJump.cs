using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossJump : MonoBehaviour
{
    public float jumpForce = 5f;
    public float jumpRange = 5f;
    bool canJump = false;
    Rigidbody2D boss;

    private void Awake()
    {
        boss = gameObject.GetComponent<Rigidbody2D>(); 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Ground")
        {
            canJump = true;             
        }
    }
    void Jump()
    {
        if (canJump)
        {
            if (boss.GetComponent<SpriteRenderer>().flipX == false)
            {
                boss.velocity = new Vector2(boss.velocity.x + jumpRange, jumpForce);
            }
            else
            {
                boss.velocity = new Vector2(boss.velocity.x - jumpRange, jumpForce);
            }
            canJump = false;
        }
    }
}
