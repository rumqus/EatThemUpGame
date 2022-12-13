using UnityEngine;
using UnityEngine.AI;

public class BigEnemy : Enemy
{


    // Start is called before the first frame update
    void Start()
    {

        Size = 1f;
        LevelofSize = 6f;
        Agent = gameObject.GetComponent<NavMeshAgent>();
        Agent.avoidancePriority = Random.RandomRange(0,25);
        Debug.Log(Agent.isActiveAndEnabled);
        target = PlayerInstance.instancePlayer.player.transform;

    }

    private void Update()
    {
        ChasePlayer();
    }

}
