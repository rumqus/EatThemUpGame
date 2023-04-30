using UnityEngine;
using UnityEngine.AI;

public class SmallEnemy : Enemy
{
// Start is called before the first frame update
    void Start()
    {
        
        Agent = gameObject.GetComponent<NavMeshAgent>();
        target = PlayerInstance.instancePlayer.player.transform;
        Agent.avoidancePriority = Random.Range(76, 99);
        Size = Random.Range(0.25f,0.4f);
        
    }

    private void Update()
    {
       ChasePlayer();
       MoveEnemy();
    }
}
