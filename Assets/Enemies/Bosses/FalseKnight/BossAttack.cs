using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public GameObject wave;
    public GameObject fireBall;
    public Transform hitCircle;
    [SerializeField] float attackRange;
    public List<Transform> Spawners = new List<Transform>();
    public int[] SpawnIndex = { 0, 1, 2, 3, 4, 5, 6, 7 }; 
    private void Awake()
    {
        Spawners = GameObject.FindGameObjectsWithTag("spawner").ToList().Select(x => x.transform).ToList();
        Shuffle(SpawnIndex); 
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
        
    }
    void FireBallAttack()
    {
        Shuffle(SpawnIndex);
        foreach (var index in SpawnIndex)
        {
            wait_a_bit(); //0.2s
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
    void wait_a_bit()
    {
        StartCoroutine( wait());
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.5f);
    }
}
