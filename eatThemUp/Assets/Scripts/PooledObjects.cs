using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledObjects : MonoBehaviour
{

    private ObjectPooler objectPooler;
    private List<GameObject> smallestEnemys;
    private List<GameObject> biggestEnemy;
    private List<GameObject> mediumEnemys;
    private List<GameObject> coins;

    private GetPoint spawnpoint;

    public List<GameObject> Coins { get; }

    private void OnEnable()
    {
        Actions.SpawnCoin += WrapCorSpawn; 
    }

    private void OnDisable()
    {
        Actions.SpawnCoin -= WrapCorSpawn;
    }

    private void Start()
    {

        spawnpoint = GetPoint.Instance;
        objectPooler = ObjectPooler.SharedInstance;
        smallestEnemys = objectPooler.GetAllPooledObjects(0);
        mediumEnemys = objectPooler.GetAllPooledObjects(1);
        biggestEnemy = objectPooler.GetAllPooledObjects(2);
        coins = objectPooler.GetAllPooledObjects(3);
        StartCoroutine(DelaySpawn());
    }


    /// <summary>
    /// method of spawning enemy
    /// </summary>
    /// <param name="enemys"></param>
    private void SpawnEnemy(List<GameObject> enemys) 
    {
        
        for (int i = 0; i < enemys.Count; i++)
        {
            GameObject pooledObject = enemys[i];
            pooledObject.transform.position = spawnpoint.GetRandomPoint();
            pooledObject.SetActive(true);
        }
    
    }
    /// <summary>
    /// Spawning enemys with delay in start scene
    /// </summary>
    /// <returns></returns>
    IEnumerator DelaySpawn() 
    {
        yield return new WaitForSeconds(1);
        SpawnEnemy(smallestEnemys);
        yield return new WaitForSeconds(2);
        SpawnEnemy(mediumEnemys);
        yield return new WaitForSeconds(3);
        SpawnEnemy(biggestEnemy);
    }


    /// <summary>
    /// wrapping coroutine to sign it on action
    /// </summary>
    /// <param name="time"></param>
    /// <param name="objects"></param>
    private void WrapCorSpawn(int time, List<GameObject> objects) 
    {
        StartCoroutine(ReSpawnDelay(time, objects));
    
    }


    IEnumerator ReSpawnDelay(int time, List<GameObject> objects) 
    {
        yield return new WaitForSeconds(time);
        ReSpawnEnemy(objects);
    }

    private void ReSpawnEnemy(List<GameObject> objects)
    {
        for (int i = 0; i < coins.Count; i++)
        {
            if (coins[i] == false)
            {
                GameObject pooledObject = coins[i];
                pooledObject.transform.position = spawnpoint.GetRandomPoint();
                pooledObject.SetActive(true);
                break;
            }
        }
    
    }

}
