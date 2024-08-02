using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public GameObject wave;
    public GameObject fireBall;
    public Transform hitCircle;
    [SerializeField] float attackRange; 
    void BasicAttack()
    {
        Collider2D hit = Physics2D.OverlapCircle(hitCircle.position, attackRange, LayerMask.GetMask("Player"));

        if (hit != null)
        {
            Debug.Log($"{hit.name} was hit"); 
        }
    }
    void WaveAttack()
    {

    }
    void FireBallAttack()
    {

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(hitCircle.position, attackRange);
    }
}
