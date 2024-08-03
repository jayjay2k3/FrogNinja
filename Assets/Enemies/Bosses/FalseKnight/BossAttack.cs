using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public GameObject wavePrefab;
    public GameObject fireBall;
    public Transform hitCircle;
    [SerializeField] float attackRange;
    public List<Transform> Spawners = new List<Transform>();
    public int[] SpawnIndex = { 0, 1, 2, 3, 4, 5, 6, 7 };
    SpriteRenderer boss;
    bool waveExist = false;
    Vector2 wavePosition;
    Vector2 flippedWavePosition;
    private void Awake()
    {
        Spawners = GameObject.FindGameObjectsWithTag("spawner").ToList().Select(x => x.transform).ToList();
        Shuffle(SpawnIndex);
        boss = gameObject.GetComponent<SpriteRenderer>();
        WavePosition();
        WaveFlippedPosiotion();
    }
    private void Update()
    {
        DestroyOutRangeWave();
    }
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
        WavePosition();
        WaveFlippedPosiotion();
        if (boss.flipX == false && waveExist == false)
        {
            GameObject cloneWave = Instantiate(wavePrefab, wavePosition, Quaternion.identity);
            cloneWave.name = "clone";
            waveExist = true;
            cloneWave.GetComponent<Rigidbody2D>().velocity = new Vector2(10f, 0f);
        }
        else if (boss.flipX == true && waveExist == false)
        {
            waveExist = true;
            GameObject cloneWave = Instantiate(wavePrefab, flippedWavePosition, Quaternion.identity);
            cloneWave.name = "clone";
            cloneWave.GetComponent<Rigidbody2D>().velocity = new Vector2(-10f, 0f);
        }
    }
    void FireBallAttack()
    {
        Shuffle(SpawnIndex);
        foreach (var index in SpawnIndex)
        {
            Instantiate(fireBall, Spawners[index].position, Quaternion.identity);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(hitCircle.position, attackRange);
    }
    void Shuffle(int[] SpawnIndex)
    {
        for(int i=0; i< SpawnIndex.Length; i++)
        {
            int j = Random.Range(i , SpawnIndex.Length - 1);
            int temp = SpawnIndex[i];
            SpawnIndex[i] = SpawnIndex[j];
            SpawnIndex[j] = temp; 
        }
    }
    void WavePosition()
    {
        wavePosition = new Vector2(boss.transform.position.x + 3f, boss.transform.position.y);
    }
    void WaveFlippedPosiotion()
    {
        float newX = boss.transform.position.x * 2 - wavePosition.x;
        flippedWavePosition = new Vector2(newX, boss.transform.position.y);
    }
    void DestroyOutRangeWave()
    {
        GameObject waveDetect = GameObject.FindWithTag("Wave");
        if (waveDetect != null && (waveDetect.transform.position.x >= 13f || waveDetect.transform.position.x <= -20f))
        {
            Destroy(waveDetect);
            waveExist = false;
        }
    }
}
