using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Coin : Enemy, IFreezeAll
{
    [SerializeField] private float lifeTimeInspector;
    private float currentLifeTime;
    private float currentSpeed;
    

    // Start is called before the first frame update
    void Start()
    {
        Agent = gameObject.GetComponent<NavMeshAgent>();
        target = PlayerInstance.instancePlayer.player.transform;
        Agent.avoidancePriority = Random.RandomRange(50, 75);
        currentLifeTime = lifeTimeInspector;
        currentSpeed = GetComponent<NavMeshAgent>().speed;

    }

    private void Update()
    {
        MoveEnemy();
        DisableCoin();

    }

    /// <summary>
    /// method of disabling coin on over lifeTime, another timer(of spawning) in SpawnerV2.cs
    /// </summary>
    /// <param name="lifeTime"></param>
    void DisableCoin() 
    {
        currentLifeTime = currentLifeTime - Time.deltaTime;
        if (currentLifeTime <= 0)
        {
           gameObject.GetComponent<NavMeshAgent>().enabled = false;
           gameObject.GetComponent<Rigidbody>().isKinematic = false;
           gameObject.GetComponent<Enemy>().grounded = false;
           gameObject.SetActive(false);
           currentLifeTime = lifeTimeInspector;
        }
    
    }

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
