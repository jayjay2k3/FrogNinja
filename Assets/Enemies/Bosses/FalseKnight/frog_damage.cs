using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frog_damage : MonoBehaviour
{
    public Health boss_health; 
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            boss_health.BossTakeDamage(30); 
        }
    }
}
