using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Coin : Enemy
{


    // Start is called before the first frame update
    void Start()
    {
        Size = 0.4f;
        LevelofSize = 0.4f;
        Agent = gameObject.GetComponent<NavMeshAgent>();
        target = PlayerInstance.instancePlayer.player.transform;
        Agent.avoidancePriority = Random.RandomRange(50, 75);
        Up = true;
        upPosition = new Vector3(ChildGO.transform.position.x, 0.8f, ChildGO.transform.position.z);
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
