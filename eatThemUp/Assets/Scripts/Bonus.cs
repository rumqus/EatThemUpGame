using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bonus : MonoBehaviour, IGrounded
{
    [SerializeField] private List<GameObject> childGO;
    private GameObject randomChild;
    [SerializeField] private float lifeTimeInspector;
    private float currentLifeTime;
    private Transform target; // target - player to chase and look
    private NavMeshAgent agent;
    [SerializeField] private float areaRadius;
    private float timer; // time for movement
    [SerializeField] private GameObject ChildGO; // child of current GO
    private Vector3 upPosition; // start position îf the object
    public bool grounded; // detecting object is on the ground
    private Rigidbody bonusRB; // bonus rigidbody

    public List<GameObject> ChildrenGO { get { return childGO; }} // need to triger bonus from player


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        bonusRB = GetComponent<Rigidbody>();
        target = PlayerInstance.instancePlayer.player.transform;
        agent.avoidancePriority = Random.Range(76, 99);
        currentLifeTime = lifeTimeInspector;
        SetRandomChildGo();
    }

    private void Update()
    {
        MoveEnemy();
        DisableBonus();
    }

    /// <summary>
    /// merhod of moving bonus
    /// </summary>
    protected void MoveEnemy()
    {
        if (agent != null)
        {
            if (!agent.hasPath && grounded == true)
            {
                bonusRB.isKinematic = true;
                agent.SetDestination(GetPoint.Instance.GetRandomPoint(transform, areaRadius));

            }
        }
    }

    


    /// <summary>
    /// activating childGO
    /// </summary>
    private void SetRandomChildGo()
    {
        randomChild = childGO[Random.Range(0, childGO.Count - 1)];
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

    /// <summary>
    /// method of disabling bonus on over lifeTime, another timer(of spawning) in SpawnerV2.cs
    /// </summary>
    /// <param name="lifeTime"></param>
    void DisableBonus()
    {
        currentLifeTime = currentLifeTime - Time.deltaTime;
        if (currentLifeTime <= 0)
        {
            DisableChildGO();
            agent.enabled = false;
            bonusRB.isKinematic = false;
            grounded = false;
            SetRandomChildGo();
            currentLifeTime = lifeTimeInspector;
            gameObject.SetActive(false); // disabling bonus
            Debug.Log("End_BonusLife");
        }
    }


    public void GroundedON()
    {
        grounded = true;
    }
}

