using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    public Slider healthBar; 
    public void Damage(float damage)
    {
        healthBar.value -= damage; 
    }
}
