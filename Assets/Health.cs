using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float BOSS_HEALTH = 500;
    public Slider health_bar;
    public void BossTakeDamage(float dmg)
    {
        health_bar.value -= dmg;
        BOSS_HEALTH -= dmg;
    }
    private void Awake()
    {
        health_bar.maxValue = BOSS_HEALTH; 
        health_bar.value = health_bar.maxValue;
    }
}
