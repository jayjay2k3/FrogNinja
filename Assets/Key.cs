using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Key : MonoBehaviour
{
    public static bool unlocked;
    private void Start()
    {
        unlocked = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "player")
        {
            unlocked = true;
            Destroy(gameObject);
        }

    }
}
