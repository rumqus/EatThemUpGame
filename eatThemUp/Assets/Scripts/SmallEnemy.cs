using UnityEngine;
using UnityEngine.AI;

public class SmallEnemy : Enemy
{

    // Start is called before the first frame update
    void Start()
    {
        Size = 0.25f;
        LevelofSize = 0.25f;
        Agent = gameObject.GetComponent<NavMeshAgent>();
        target = PlayerInstance.instancePlayer.player.transform;
        Agent.avoidancePriority = Random.Range(76, 99);
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
