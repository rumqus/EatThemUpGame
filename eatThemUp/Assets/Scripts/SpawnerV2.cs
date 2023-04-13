using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnerV2 : MonoBehaviour
{
    [SerializeField] private Vector3 center;
    [SerializeField] int range;
    [SerializeField] float yPos;
    [SerializeField] GameObject prefab;
    [SerializeField] GameObject objectPooler;
    [SerializeField] int smallEnemyCount;
    [SerializeField] int mediumEnemyCount;
    [SerializeField] int bigEnemyCount;

    private void OnEnable()
    {
        Actions.RespawnEnemy += SpawnItem;
    }

    private void OnDisable()
    {
        Actions.RespawnEnemy -= SpawnItem;
    }



    // Start is called before the first frame update
    void Start()
    {
        SpawnItem(objectPooler.GetComponent<PooledObjects>().smallestEnemy, smallEnemyCount);
    }
    void SpawnItem(List<GameObject> enemys, int number)
    {
        int countActived = 0;

        for (int i = 0; i < enemys.Count; i++)
        {
            if (enemys[i].gameObject.active == false)
            {
                if (countActived < number)
                {
                    Vector3 pos = center + new Vector3(Random.Range(-range / 2, range / 2), yPos, Random.Range(-range / 2, range / 2));
                    GameObject poolledObject = enemys[i];
                    poolledObject.GetComponent<Rigidbody>().isKinematic = false;
                    poolledObject.transform.position = pos;
                    poolledObject.SetActive(true);
                    countActived++;
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.3f);
        Gizmos.DrawSphere(center, range);
    }
}
