using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceCheck : MonoBehaviour
{
    public float range = 8;
    public Transform rhino; 
    public Transform player;
    public Animator anim; 
    private void Update()
    {
        rhino.GetComponent<SpriteRenderer>().flipX = player.transform.position.x > rhino.transform.position.x;
        if (Vector2.Distance(rhino.position, player.position) <= range)
        {
            anim.SetTrigger("Run"); 
        }
    }
}
