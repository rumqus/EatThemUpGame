using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledObjects : MonoBehaviour
{
    [SerializeField] private List<GameObject> spawnAreas;
    private ObjectPooler objectPooler;
    private List<GameObject> smallestEnemys;
    private List<GameObject> biggestEnemy;
    private List<GameObject> mediumEnemys;
    private List<GameObject> coins;
    private GetPoint spawnpoint;

    public List<GameObject> Coins { get { return coins;} }
    public List<GameObject> smallestEnemy { get { return smallestEnemys;} }
    public List<GameObject> BiggestEnemy { get { return biggestEnemy;} }
    public List<GameObject> MediumEnemys { get { return mediumEnemys;} }

    private void OnEnable()
    {
        Actions.SpawnCoin += SpawnCoin;
        Actions.RespawnEnemy += WrapCorSpawn;
    }

    private void OnDisable()
    {
        Actions.SpawnCoin -= SpawnCoin;
        Actions.RespawnEnemy -= WrapCorSpawn;
    }

    private void Start()
    {
        spawnpoint = GetComponent<GetPoint>();
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
    private void SpawnEnemy(List<GameObject> enemys, int count) 
    {
        for (int i = 0; i < spawnAreas.Count; i++)
        {
            for (int j = 0; j < count; j++)
            {
                GameObject pooledObject = enemys[j];
                pooledObject.transform.position = spawnpoint.GetRandomPoint(spawnAreas[i].transform, spawnAreas[i].GetComponent<GetPoint>().Range);
                pooledObject.SetActive(true);
            }

        }

        
    }
    /// <summary>
    /// Spawning enemys with delay in start scene, SpawnEnemy(type of the enemy, number of the enemy)
    /// </summary>
    /// <returns></returns>
    IEnumerator DelaySpawn() 
    {
        yield return new WaitForSeconds(1);
        SpawnEnemy(smallestEnemys, 5);
        yield return new WaitForSeconds(2);
        SpawnEnemy(mediumEnemys, 5);
        yield return new WaitForSeconds(3);
        SpawnEnemy(biggestEnemy, 5);
        yield return new WaitForSeconds(5);
        SpawnCoin();
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

    /// <summary>
    /// Coroutine to delay spawnEnemy
    /// </summary>
    /// <param name="time"></param>
    /// <param name="objects"></param>
    /// <returns></returns>
    IEnumerator ReSpawnDelay(int time, List<GameObject> objects) 
    {
        yield return new WaitForSeconds(time);
        ReSpawnEnemy(objects);
    }
    /// <summary>
    /// method of respawning enemy
    /// </summary>
    /// <param name="objects"></param>
    private void ReSpawnEnemy(List<GameObject> objects)
    {
        int count = 0;
        for (int i = 0; i < objects.Count; i++)
        {
            if (count < 1)
            {
                if (objects[i].activeSelf == false)
                {
                    GameObject pooledObject = objects[i];
                    pooledObject.transform.position = spawnpoint.GetRandomPoint();
                    pooledObject.SetActive(true);
                    count++;
                }
            }
        }
    
    }

    /// <summary>
    /// Method of spawning and respawning coins with wrapped corutine
    /// </summary>
    private void SpawnCoin() 
    {
        StartCoroutine(DelayCoinSpawn());
    }

    /// <summary>
    /// count < 1 - change amount of coins spawn
    /// </summary>
    /// <returns></returns>
    IEnumerator DelayCoinSpawn() 
    {
        // монструозная херня
        int count = 0;
        yield return new WaitForSeconds(5);
        // after delay spawn coin
        for (int i = 0; i < coins.Count; i++)
        {
            if (count < 1)
            {
                if (coins[i].activeSelf == false)
                {
                    GameObject pooledObject = coins[i];
                    pooledObject.transform.position = spawnpoint.GetRandomPoint();
                    pooledObject.SetActive(true);
                    count++;
                    
                }
            }
        }
    }

}
