using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Coin : Enemy
{
    [SerializeField] private float lifeTime;
    [SerializeField] private float DwlaySpawnCoin;
    private float currentLifeTime;
    

    // Start is called before the first frame update
    void Start()
    {
        Agent = gameObject.GetComponent<NavMeshAgent>();
        target = PlayerInstance.instancePlayer.player.transform;
        Agent.avoidancePriority = Random.RandomRange(50, 75);
        currentLifeTime = lifeTime;
    }

    private void Update()
    {
        MoveEnemy();
        DisableCoin(currentLifeTime);
    }

    /// <summary>
    /// method of disabling coin on over lifeTime, another timer(of spawning) in SpawnerV2.cs
    /// </summary>
    /// <param name="lifeTime"></param>
    void DisableCoin(float lifeTime) 
    {
        lifeTime = lifeTime - Time.deltaTime;
        if (lifeTime <= 0)
        {
           gameObject.GetComponent<NavMeshAgent>().enabled = false;
           gameObject.GetComponent<Rigidbody>().isKinematic = false;
           gameObject.GetComponent<Enemy>().grounded = false;
           gameObject.SetActive(false);
           currentLifeTime = lifeTime;
        }
    
    }


}
