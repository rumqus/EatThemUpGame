using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerV2 : MonoBehaviour
{
    [SerializeField] private Vector3 center;
    [SerializeField] int range;
    [SerializeField] float yPos;
    [SerializeField] GameObject prefab;
    [SerializeField] GameObject objectPooler;
    


    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
        SpawnItem(objectPooler.GetComponent<PooledObjects>().smallestEnemy,10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnItem(List<GameObject> enemys,int number) 
    {
        for (int i = 0; i < number; i++)
        {
            Vector3 pos = center + new Vector3(Random.Range(-range / 2, range / 2), yPos, Random.Range(-range / 2, range / 2));
            GameObject poolledObject = enemys[i];
            poolledObject.transform.position = pos;
            poolledObject.SetActive(true);
        }
    
    }

    void ReSpawnItem() 
    {
    
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.3f);
        Gizmos.DrawSphere(center,range);
        
    }
}
