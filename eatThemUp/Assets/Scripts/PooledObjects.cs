using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledObjects : MonoBehaviour
{

    private ObjectPooler objectPooler;
    private List<GameObject> smallestEnemys;
    private List<GameObject> biggestEnemy;
    private List<GameObject> mediumEnemys;
    


    private GetPoint spawnpoint; 

 

    private void Start()
    {

        spawnpoint = GetPoint.Instance;
        objectPooler = ObjectPooler.SharedInstance;
        smallestEnemys = objectPooler.GetAllPooledObjects(0);
        mediumEnemys = objectPooler.GetAllPooledObjects(1);
        biggestEnemy = objectPooler.GetAllPooledObjects(2);
        StartCoroutine(delaySpawn());
    }

    private void SpawnEnemy(List<GameObject> enemys) 
    {
        
        for (int i = 0; i < enemys.Count; i++)
        {
            GameObject pooledObject = enemys[i];
            pooledObject.transform.position = spawnpoint.GetRandomPoint();
            pooledObject.SetActive(true);
           // Debug.Log($@"spawn enemy_{pooledObject.transform.position}");
        }
    
    }

    IEnumerator delaySpawn() 
    {
        yield return new WaitForSeconds(1);
        SpawnEnemy(smallestEnemys);
        yield return new WaitForSeconds(2);
        SpawnEnemy(mediumEnemys);
        yield return new WaitForSeconds(3);
        SpawnEnemy(biggestEnemy);
    }

}
