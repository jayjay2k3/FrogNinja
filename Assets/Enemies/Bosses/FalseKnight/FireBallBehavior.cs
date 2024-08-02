using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallBehavior : MonoBehaviour
{
    public GameObject fireBallDestroyed;
    float i = 0;
    private void Update()
    {
        i += 1;
        transform.rotation = Quaternion.Euler(0, 0, i);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            var destroyedEffect = Instantiate(fireBallDestroyed, transform.position, Quaternion.identity);
            destroyedEffect.GetComponent<ParticleSystem>().Play();
            Destroy(destroyedEffect, 1f);
            Destroy(gameObject, 0.2f);
        }
    }
}
