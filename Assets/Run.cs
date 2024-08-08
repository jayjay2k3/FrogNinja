using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Run : StateMachineBehaviour
{
    Rigidbody2D boss;
    Transform player; 
    public float speed = 5f;
    public float attackTriggerRange = 3f; 
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss = animator.GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector2 target = new Vector2(player.position.x, boss.position.y);
        Vector2 moveDirection = Vector2.MoveTowards(boss.position, target, speed * Time.fixedDeltaTime);
        boss.MovePosition(moveDirection); 
        if(Vector2.Distance(boss.position, player.position) <= attackTriggerRange)
        {
            animator.SetTrigger("Attack"); 
        }
    }
}
