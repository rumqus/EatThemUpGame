using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledObjects : MonoBehaviour
{

    private ObjectPooler objectPooler;
    private List<GameObject> objects;
    private GetPoint spawnpoint; 

 

    private void Start()
    {
        spawnpoint = GetComponent<GetPoint>();
        objectPooler = ObjectPooler.SharedInstance;
        objects = objectPooler.GetAllPooledObjects(0);
        SpawnEnemy();
    }

    private void SpawnEnemy() 
    {
        for (int i = 0; i < objects.Count; i++)
        {
            GameObject pooledObject = objects[i];
            pooledObject.transform.position = spawnpoint.GetRandomPoint();
            pooledObject.SetActive(true);
        }
    
    }
}
