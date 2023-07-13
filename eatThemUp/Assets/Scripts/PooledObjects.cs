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
    private List<GameObject> bonus;
    private List<List<GameObject>> AllpooledObject;
 

    public const int LOCATION = 4;
    public const float FREEZETIME = 5;
    
    public List<GameObject> Coins { get { return coins;} }
    public List<GameObject> SmallestEnemy { get { return smallestEnemys;} }
    public List<GameObject> BiggestEnemy { get { return biggestEnemy;} }
    public List<GameObject> MediumEnemys { get { return mediumEnemys;} }
    public List<GameObject> Bonus { get { return bonus; } }

    private void OnEnable()
    {
        Actions.DisableObjects += DisableItems;
        Actions.freezeAll += FreezeAllObjects;
    }

    private void OnDisable()
    {
        Actions.DisableObjects -= DisableItems;
        Actions.freezeAll -= FreezeAllObjects;
    }

    private void Awake()
    {
        objectPooler = ObjectPooler.SharedInstance;
        smallestEnemys = objectPooler.GetAllPooledObjects(0);
        mediumEnemys = objectPooler.GetAllPooledObjects(1);
        biggestEnemy = objectPooler.GetAllPooledObjects(2);
        bonus = objectPooler.GetAllPooledObjects(3);
        AllpooledObject = new List<List<GameObject>>() { smallestEnemys, mediumEnemys, biggestEnemy, bonus };
    }

    /// <summary>
    /// method of freezing all pooled objects
    /// </summary>
    private void FreezeAllObjects() 
    {
        foreach (List<GameObject> list in AllpooledObject)
        {
            foreach (GameObject item in list)
            {
                if (item.activeInHierarchy == true)
                {
                    if (item.TryGetComponent<Enemy>(out Enemy enemy) && enemy.grounded == true)
                    {
                        item.GetComponent<IFreezeAll>().FreezeAll();
                    }
                }
            }
        }
    }


    /// <summary>
    /// disabling unnecessary elements on locations, with respawning objects
    /// </summary>
    /// <param name="items"></param>
    /// <param name="locations"></param>
    void DisableItems(List<GameObject> items,int locations) 
    {
        int count = locations - 1;
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
