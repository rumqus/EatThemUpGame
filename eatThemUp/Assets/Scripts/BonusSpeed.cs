using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BonusSpeed : Enemy
{
    [SerializeField] private List<GameObject> childGOs;

    // Start is called before the first frame update
    void Start()
    {
        Agent = gameObject.GetComponent<NavMeshAgent>();
        target = PlayerInstance.instancePlayer.player.transform;
        Agent.avoidancePriority = Random.RandomRange(50, 75);
        
    }

    private void Update()
    {
        MoveEnemy();
    }

    interface Bonus { };

}
