using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class SmallEnemy : Enemy, IFreezeAll
{
    private float currentSpeed;
// Start is called before the first frame update
    void Start()
    {
        Agent = gameObject.GetComponent<NavMeshAgent>();
        target = PlayerInstance.instancePlayer.player.transform;
        Agent.avoidancePriority = Random.Range(76, 99);
        Size = Random.Range(0.25f,0.4f);
        currentSpeed = GetComponent<NavMeshAgent>().speed;
    }

    private void Update()
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
