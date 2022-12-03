using UnityEngine;
using UnityEngine.AI;

public class MediumEnemy : Enemy
{

    // Start is called before the first frame update
    void Start()
    {

        Size = 0.4f;
        LevelofSize = 0.4f;
        Agent = gameObject.GetComponent<NavMeshAgent>();
        target = PlayerInstance.instancePlayer.player.transform;

    }

    private void Update()
    {
        ChasePlayer();
    }
}
