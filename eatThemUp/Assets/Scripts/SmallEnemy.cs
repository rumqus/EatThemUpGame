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
        
    }

    private void Update()
    {
       ChasePlayer();
       MoveEnemy();
    }
}
