using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnerV2 : MonoBehaviour
{
    [SerializeField] private Vector3 center;
    [SerializeField] int range;
    [SerializeField] float yPos;
    [SerializeField] private GameObject objectPooler;
    [SerializeField] int smallEnemyCount;
    [SerializeField] int mediumEnemyCount;
    [SerializeField] int bigEnemyCount;
    [SerializeField] private GameObject self;
    

    private void OnEnable()
    {
        Actions.RespawnEnemy += SpawnItem;
        Actions.SpawnOneItem += SpawnOneEnemy;
    }

    private void OnDisable()
    {
        Actions.RespawnEnemy -= SpawnItem;
        Actions.SpawnOneItem -= SpawnOneEnemy;
    }



    // Start is called before the first frame update
    void Start()
    {
        StartSpawn(smallEnemyCount,objectPooler.GetComponent<PooledObjects>().smallestEnemy);
        StartSpawn(mediumEnemyCount,objectPooler.GetComponent<PooledObjects>().MediumEnemys);
        StartSpawn(bigEnemyCount,objectPooler.GetComponent<PooledObjects>().BiggestEnemy);

    }

    void StartSpawn(int count,List<GameObject> items) 
    {
        for (int i = 0; i < count; i++)
        {
            float DelayTime = Random.Range(1, 5);
            StartCoroutine(DelaySpawnStart(items, 1, DelayTime));
        }
    }


    private void SpawnItem(List<GameObject> enemys, int number)
    {
        int countActived = 0;
        for (int i = 0; i < enemys.Count; i++)
        {
            if (enemys[i].active == false && countActived < number)
            {
                //Actions.SpawnOneItem(enemys[i]);
                Vector3 pos = center + new Vector3(Random.Range(-range / 2, range / 2), yPos, Random.Range(-range / 2, range / 2));
               
                GameObject poolledObject = enemys[i];
                poolledObject.GetComponent<Rigidbody>().isKinematic = false;
                poolledObject.transform.position = pos;
                enemys[i].SetActive(true);

                countActived++;
            }
        }
        
    }

    void SpawnOneEnemy(GameObject enemy) 
    {
        
        Vector3 pos = center + new Vector3(Random.Range(-range / 2, range / 2), yPos, Random.Range(-range / 2, range / 2));
        Debug.Log(pos);
        GameObject poolledObject = enemy;
        poolledObject.GetComponent<Rigidbody>().isKinematic = false;
        poolledObject.transform.position = pos;
        enemy.SetActive(true);
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.3f);
        Gizmos.DrawSphere(center, range);
    }

    IEnumerator DelaySpawnStart(List<GameObject> items, int count, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SpawnItem(items, count);
    }

}
