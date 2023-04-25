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

    public const int LOCATION = 1;
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
        int count = locations - 1;
        //items.Reverse();
        //List<GameObject> activeList = new List<GameObject>();
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].active == true && count > 0)
            {
                items[i].GetComponent<NavMeshAgent>().enabled = false;
                items[i].GetComponent<Rigidbody>().isKinematic = false;
                items[i].GetComponent<Enemy>().grounded = false;
                items[i].SetActive(false);
                count--;
            }

        }

    }



}
