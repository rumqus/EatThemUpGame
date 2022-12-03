using UnityEngine;
using UnityEngine.AI;

public class MediumEnemyV2 : Enemy
{

    // Start is called before the first frame update
    void Start()
    {

        Size = 0.8f;
        LevelofSize = 0.8f;
        Agent = gameObject.GetComponent<NavMeshAgent>();
        target = PlayerInstance.instancePlayer.player.transform;

    }

    private void Update()
    {
        ChasePlayer();
    }
}
