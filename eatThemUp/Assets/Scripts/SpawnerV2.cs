using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnerV2 : MonoBehaviour
{
    [SerializeField] private Vector3 center; // center of spawning area
    [SerializeField] int range; // radius of spawning area
    [SerializeField] float yPos; // up position of spawn
    [SerializeField] private GameObject objectPooler; // reference to gameobject pooledobject
    [SerializeField] int smallEnemyCount; // number to spawn
    [SerializeField] int mediumEnemyCount; // number to spawn
    [SerializeField] int bigEnemyCount; // number to spawn
    //[SerializeField] int coins; // number to spawn
    [SerializeField] int bonus; // number to spawn
    [SerializeField] private GameObject self;
    [SerializeField] float delayTimeCoin;
    private float currentDelayCoin;
    [SerializeField] float delayTimeBonus;
    private float currentDelayBonus;


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
        // spawning objects on start game
        StartSpawn(smallEnemyCount, objectPooler.GetComponent<PooledObjects>().SmallestEnemy);
        StartSpawn(mediumEnemyCount, objectPooler.GetComponent<PooledObjects>().MediumEnemys);
        StartSpawn(bigEnemyCount, objectPooler.GetComponent<PooledObjects>().BiggestEnemy);
        //StartSpawn(coins, objectPooler.GetComponent<PooledObjects>().Coins);
        StartSpawn(bonus, objectPooler.GetComponent<PooledObjects>().Bonus);
        currentDelayCoin = delayTimeCoin;
        currentDelayBonus = delayTimeBonus;
    }
    private void Update()
    {
        //SpawnCoin();
        SpawnBonus();
    }

    private void SpawnBonus()
    {
        currentDelayBonus = currentDelayBonus - Time.deltaTime;
        if (currentDelayBonus < 0)
        {
            StartSpawn(bonus, objectPooler.GetComponent<PooledObjects>().Bonus);
            currentDelayBonus = delayTimeBonus;
        }
    }

    /// <summary>
    /// wraping corutine to spawn enemys\coins in start
    /// </summary>
    /// <param name="count"></param>
    /// <param name="items"></param>
    void StartSpawn(int count, List<GameObject> items)
    {
        for (int i = 0; i < count; i++)
        {
            float DelayTime = Random.Range(1, 7); // delay time to spawn
            StartCoroutine(DelaySpawnStart(items, 1, DelayTime));
        }
    }

    /// <summary>
    /// method of spawning enemys
    /// </summary>
    /// <param name="enemys"></param>
    /// <param name="number"></param>
    private void SpawnItem(List<GameObject> enemys, int number)
    {
        int countActived = 0;
        for (int i = 0; i < enemys.Count; i++)
        {
            if (enemys[i].active == false && countActived < number)
            {
                //Vector3 pos = center + new Vector3(Random.Range(-range / 2, range / 2), yPos, Random.Range(-range / 2, range / 2));
                Transform transform = gameObject.transform;
                transform.position = center + new Vector3(Random.Range(-range / 2, range / 2), yPos, Random.Range(-range / 2, range / 2));
                Vector3 pos = GetPoint.Instance.GetRandomPoint(transform, range);
                GameObject poolledObject = enemys[i];
                poolledObject.GetComponent<Rigidbody>().isKinematic = false;
                poolledObject.transform.position = new Vector3(pos.x,yPos,pos.z);
                enemys[i].SetActive(true);
                countActived++;
            }
        }
    }

    /// <summary>
    /// method to spawn one object
    /// </summary>
    /// <param name="enemy"></param>
    void SpawnOneEnemy(List<GameObject> enemys)
    {
        int delayTime = Random.Range(5, 10);
        StartCoroutine(DelaySpawnOne(delayTime));
        IEnumerator DelaySpawnOne(int seconds) 
        {
            yield return new WaitForSeconds(seconds);
            SpawnItem(enemys, 1); // respawning one item
        }
    }

    /// <summary>
    /// tech to draw spawning area
    /// </summary>
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
