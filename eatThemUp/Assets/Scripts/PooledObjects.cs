using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PooledObjects : MonoBehaviour
{
    
    private ObjectPooler objectPooler;
    private List<GameObject> smallestEnemys;
    private List<GameObject> biggestEnemy;
    private List<GameObject> mediumEnemys;
    private List<GameObject> coins;
    [SerializeField] private int locations;

    public const int LOCATION = 4;
    public List<GameObject> Coins { get { return coins;} }
    public List<GameObject> smallestEnemy { get { return smallestEnemys;} }
    public List<GameObject> BiggestEnemy { get { return biggestEnemy;} }
    public List<GameObject> MediumEnemys { get { return mediumEnemys;} }

    private void OnEnable()
    {
        Actions.DisableObjects += DisableItems;
    }

    private void OnDisable()
    {
        Actions.DisableObjects -= DisableItems;
    }

    private void Awake()
    {
        objectPooler = ObjectPooler.SharedInstance;
        smallestEnemys = objectPooler.GetAllPooledObjects(0);
        mediumEnemys = objectPooler.GetAllPooledObjects(1);
        biggestEnemy = objectPooler.GetAllPooledObjects(2);
        coins = objectPooler.GetAllPooledObjects(3);
    }

    void DisableItems(List<GameObject> items,int locations) 
    {
        int count = locations-1;
        items.Reverse();
        List<GameObject> activeList = new List<GameObject>();
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].active == true && count > 0 )
            {
                
                activeList.Add(items[i]);
            }

        }


        if (activeList.Count > 0)
        {
            for (int j = activeList.Count - 1; j > 0; j--)
            {
                if (count > 0)
                {
                    activeList[j].GetComponent<NavMeshAgent>().enabled = false;
                    activeList[j].GetComponent<Rigidbody>().isKinematic = false;
                    activeList[j].GetComponent<Enemy>().grounded = false;
                    activeList[j].SetActive(false);
                    count--;
                }
                else
                {
                    return;
                }
            }
        }

    }

    ///// <summary>
    ///// method of spawning enemy
    ///// </summary>
    ///// <param name="enemys"></param>
    //private void SpawnEnemy(List<GameObject> enemys, int count) 
    //{
    //    for (int i = 0; i < spawnAreas.Count; i++)
    //    {
    //        for (int j = 0; j < count; j++)
    //        {
    //            GameObject pooledObject = enemys[j];
    //            pooledObject.transform.position = spawnpoint.GetRandomPoint(spawnAreas[i].transform, spawnAreas[i].GetComponent<GetPoint>().Range);
    //            pooledObject.SetActive(true);
    //        }

    //    }

        
    //}
    ///// <summary>
    ///// Spawning enemys with delay in start scene, SpawnEnemy(type of the enemy, number of the enemy)
    ///// </summary>
    ///// <returns></returns>
    //IEnumerator DelaySpawn() 
    //{
    //    yield return new WaitForSeconds(1);
    //    SpawnEnemy(smallestEnemys, 5);
    //    yield return new WaitForSeconds(2);
    //    SpawnEnemy(mediumEnemys, 5);
    //    yield return new WaitForSeconds(3);
    //    SpawnEnemy(biggestEnemy, 5);
    //    yield return new WaitForSeconds(5);
    //    SpawnCoin();
    //}

    ///// <summary>
    ///// wrapping coroutine to sign it on action
    ///// </summary>
    ///// <param name="time"></param>
    ///// <param name="objects"></param>
    //private void WrapCorSpawn(int time, List<GameObject> objects) 
    //{
    //    StartCoroutine(ReSpawnDelay(time, objects));
    //}

    ///// <summary>
    ///// Coroutine to delay spawnEnemy
    ///// </summary>
    ///// <param name="time"></param>
    ///// <param name="objects"></param>
    ///// <returns></returns>
    //IEnumerator ReSpawnDelay(int time, List<GameObject> objects) 
    //{
    //    yield return new WaitForSeconds(time);
    //    ReSpawnEnemy(objects);
    //}
    ///// <summary>
    ///// method of respawning enemy
    ///// </summary>
    ///// <param name="objects"></param>
    //private void ReSpawnEnemy(List<GameObject> objects)
    //{
    //    int count = 0;
    //    for (int i = 0; i < objects.Count; i++)
    //    {
    //        if (count < 1)
    //        {
    //            if (objects[i].activeSelf == false)
    //            {
    //                GameObject pooledObject = objects[i];
    //                pooledObject.transform.position = spawnpoint.GetRandomPoint();
    //                pooledObject.SetActive(true);
    //                count++;
    //            }
    //        }
    //    }
    
    //}

    ///// <summary>
    ///// Method of spawning and respawning coins with wrapped corutine
    ///// </summary>
    //private void SpawnCoin() 
    //{
    //    StartCoroutine(DelayCoinSpawn());
    //}

    ///// <summary>
    ///// count < 1 - change amount of coins spawn
    ///// </summary>
    ///// <returns></returns>
    //IEnumerator DelayCoinSpawn() 
    //{
    //    // монструозная херня
    //    int count = 0;
    //    yield return new WaitForSeconds(5);
    //    // after delay spawn coin
    //    for (int i = 0; i < coins.Count; i++)
    //    {
    //        if (count < 1)
    //        {
    //            if (coins[i].activeSelf == false)
    //            {
    //                GameObject pooledObject = coins[i];
    //                pooledObject.transform.position = spawnpoint.GetRandomPoint();
    //                pooledObject.SetActive(true);
    //                count++;
                    
    //            }
    //        }
    //    }
    //}

}
