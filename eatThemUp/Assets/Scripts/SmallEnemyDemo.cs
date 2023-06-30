using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SmallEnemyDemo : Enemy
{
    [SerializeField] private Animator enemyAnimator;
    void Start()
    {

        Agent = gameObject.GetComponent<NavMeshAgent>();
        target = PlayerInstance.instancePlayer.player.transform;
        Agent.avoidancePriority = Random.Range(25, 73);
        Size = Random.Range(0.25f, 0.4f);
    }

    private void Update()
    {
        if (Agent.speed != 0)
        {
            ChasePlayer();
            MoveEnemy();
        }
    }

    private void OnEnable()
    {
        enemyAnimator.enabled = true;

    }
}
