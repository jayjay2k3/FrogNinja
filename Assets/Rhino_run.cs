using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rhino_run : StateMachineBehaviour
{
    Rigidbody2D rhino;
    Transform player;
    public float speed = 3f;
    public float OutRange = 5f;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rhino = animator.GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector2 target = new Vector2(player.position.x, rhino.position.y);
        Vector2 moveDirection = Vector2.MoveTowards(rhino.position, target, speed * Time.fixedDeltaTime);
        rhino.MovePosition(moveDirection);
        if(Vector2.Distance(rhino.position, player.position) > OutRange)
        {
            animator.SetTrigger("Idle"); 
        }
    }
}
