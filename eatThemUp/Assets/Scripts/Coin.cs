using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Coin : Enemy
{


    // Start is called before the first frame update
    void Start()
    {
        Agent = gameObject.GetComponent<NavMeshAgent>();
        target = PlayerInstance.instancePlayer.player.transform;
        Agent.avoidancePriority = Random.RandomRange(50, 75);        
    }

    private void Update()
    {
        MoveEnemy();
    }

    IEnumerator SpawnCoin() 
    {
        yield return new WaitForSeconds(5);
        // destroy coin
    }

}
