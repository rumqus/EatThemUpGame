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
        target = PlayerInstance.instancePlayer.player.transform;
        Up = true;
        upPosition = new Vector3(ChildGO.transform.position.x, 13f, ChildGO.transform.position.z);
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
