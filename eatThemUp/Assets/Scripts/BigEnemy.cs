using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BigEnemy : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        LevelofSize = 6f;
        Agent = gameObject.GetComponent<NavMeshAgent>();
        target = PlayerInstance.instancePlayer.player.transform;
        Agent.avoidancePriority = Random.Range(76, 99);
    }

    // Update is called once per frame
    void Update()
    {
        ChasePlayer();
        MoveEnemy();
    }
}
