using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bonus : Enemy
{
    [SerializeField] private List<GameObject> childGO;
    private GameObject randomChild;
    void Start()
    {
        randomChild = childGO[Random.Range(0, childGO.Count -1)];
        Agent = gameObject.GetComponent<NavMeshAgent>();
        target = PlayerInstance.instancePlayer.player.transform;
        Agent.avoidancePriority = Random.Range(76, 99);
        Size = Random.Range(0.25f, 0.4f);
    }

    private void Update()
    {
        ChasePlayer();
        MoveEnemy();
    }

    private void SetRandomChildGo() 
    {
        randomChild.SetActive(true);
    }

    private void DisableChildGO(GameObject item)
    {

    }
}

