using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BigEnemy : Enemy, IFreezeAll
{

    private float currentSpeed;

    // Start is called before the first frame update
    void Start()
    {
        LevelofSize = 6f;
        Agent = gameObject.GetComponent<NavMeshAgent>();
        target = PlayerInstance.instancePlayer.player.transform;
        Agent.avoidancePriority = Random.Range(76, 99);
        currentSpeed = GetComponent<NavMeshAgent>().speed;
    }

    // Update is called once per frame
    void Update()
    {
        ChasePlayer();
        MoveEnemy();
    }

    /// <summary>
    /// method to freeze all object ob location
    /// </summary>
    public void FreezeAll()
    {
        GetComponent<NavMeshAgent>().speed = 0;
        StartCoroutine(FreezeTime(PooledObjects.FREEZETIME));
    }

    IEnumerator FreezeTime(float freezeTime)
    {
        yield return new WaitForSeconds(freezeTime);
        GetComponent<NavMeshAgent>().speed = currentSpeed;
    }

}
