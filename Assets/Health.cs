using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Animator animator; 
    public float BOSS_HEALTH = 500;
    public Slider health_bar;
    float hundred = 0; 
    public void BossTakeDamage(float dmg)
    {
        health_bar.value -= dmg;
        BOSS_HEALTH -= dmg;
        hundred += dmg; 
    }
    private void Awake()
    {
        health_bar.maxValue = BOSS_HEALTH; 
        health_bar.value = health_bar.maxValue;
    }
    private void Update()
    {
        if(BOSS_HEALTH <= 0)
        {
            animator.SetTrigger("Dead");  
        }
        else if(hundred >= 100)
        {
            hundred = 0;
            animator.SetTrigger("Roll"); 
        }
    }
}
