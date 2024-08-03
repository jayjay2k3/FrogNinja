using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkAttackBehavior: MonoBehaviour
{
    Vector2 bulletSpawn;
    Vector2 flippedBulletSpawn;
    public GameObject bulletPrefab;
    float timer = 0;
    const float RELOAD_TIME = 0.55f;
    private void Update()
    {
        gameObject.GetComponent<SpriteRenderer>().flipX = GameObject.FindWithTag("Player").GetComponent<Transform>().position.x > gameObject.transform.position.x;
        timer += Time.deltaTime;  
    }
    void BulletPosition()
    {
        bulletSpawn = new Vector2(gameObject.transform.position.x + 1f, gameObject.transform.position.y);
    }
    void BulletFlippedPosiotion()
    {
        float newX = gameObject.transform.position.x * 2 - bulletSpawn.x; 
        flippedBulletSpawn = new Vector2(newX, gameObject.transform.position.y);
    }

    void BulletAttack()
    {
        if(timer >= RELOAD_TIME)
        {
            timer = 0;
            BulletPosition();
            BulletFlippedPosiotion();
            if (gameObject.GetComponent<SpriteRenderer>().flipX == false)
            {
                GameObject cloneWave = Instantiate(bulletPrefab, bulletSpawn, Quaternion.identity);
                cloneWave.name = "clone";

                cloneWave.GetComponent<Rigidbody2D>().velocity = new Vector2(-5f, 0f);
            }
            else if (gameObject.GetComponent<SpriteRenderer>().flipX == true)
            {

                GameObject cloneWave = Instantiate(bulletPrefab, flippedBulletSpawn, Quaternion.identity);
                cloneWave.name = "clone";
                cloneWave.GetComponent<Rigidbody2D>().velocity = new Vector2(5f, 0f);
            }
        }
    }
}
