using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bonus : Enemy
{
    [SerializeField] private List<GameObject> childGO;
    private GameObject randomChild;

    private void OnEnable()
    {
        Actions.DisableChildGO += DisableChildGO;
    }

    private void OnDisable()
    {
        Actions.DisableChildGO -= DisableChildGO;
    }

    void Start()
    {
        randomChild = childGO[Random.Range(0, childGO.Count -1)];
        Agent = gameObject.GetComponent<NavMeshAgent>();
        target = PlayerInstance.instancePlayer.player.transform;
        Agent.avoidancePriority = Random.Range(76, 99);
        Size = Random.Range(0.25f, 0.4f);
        SetRandomChildGo();
    }

    private void Update()
    {
        ChasePlayer();
        MoveEnemy();
    }

    /// <summary>
    /// acticating childGO
    /// </summary>
    private void SetRandomChildGo() 
    {
        ChildGO = randomChild;
        randomChild.SetActive(true);
    }

    /// <summary>
    /// disabling ChilGo
    /// </summary>
    /// <param name="item"></param>
    public void DisableChildGO()
    {
        for (int i = 0; i < childGO.Count; i++)
        {
            ChildGO.SetActive(false);
        }
    }
}

