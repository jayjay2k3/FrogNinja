using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFlip : MonoBehaviour
{
    public GameObject boss; 
    public GameObject player;   
    private void Update()
    {
        boss.GetComponent<SpriteRenderer>().flipX = player.transform.position.x < boss.transform.position.x;
    }
}
