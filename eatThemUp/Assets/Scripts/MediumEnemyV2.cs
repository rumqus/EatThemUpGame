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
        Agent.avoidancePriority = Random.RandomRange(26, 50);
        target = PlayerInstance.instancePlayer.player.transform;
        Up = true;
        upPosition = new Vector3(ChildGO.transform.position.x, 0.8f, ChildGO.transform.position.z);

    }

    private void Update()
    {
        if (Up == true)
        {
            StartMovement();
        }
        else
        {
            ChasePlayer();
            MoveEnemy();
        }
    }
}
