using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBehavior : StateMachineBehaviour
{

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector2 direction = animator.GetComponent<SpriteRenderer>().flipX ? Vector2.left : Vector2.right;
        RaycastHit2D hit = Physics2D.Raycast(animator.GetComponent<Transform>().position, direction, 10f);
        if (hit.collider != null && hit.collider.tag == "Player") 
        {
            Debug.Log("hit"); 
        }
    }
}
