using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bonus : MonoBehaviour, IGrounded, IFreezeAll
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
    private float freezeTime; // time of freezingEnemy
    private float currentSpeed;
    

    public List<GameObject> ChildrenGO { get { return childGO; }} // need to triger bonus from player


    void Start()
    {
        currentSpeed = 9f; // speed of bonuis
        agent = GetComponent<NavMeshAgent>();
        bonusRB = GetComponent<Rigidbody>();
        target = PlayerInstance.instancePlayer.player.transform;
        agent.avoidancePriority = Random.Range(76, 99);
        currentLifeTime = lifeTimeInspector; // lige of bonus
    }

    private void Update()
    {
        MoveEnemy();
        DisableBonus();
    }

    private void OnEnable()
    {
        SetRandomChildGo(); // Set new bonus
    }

    /// <summary>
    /// method of moving bonus
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
        DisableChildGO();
        randomChild = childGO[Random.Range(0, childGO.Count)];
        ChildGO = randomChild;
        randomChild.SetActive(true);

    }
    /// <summary>
    /// disabling ChilGo
    /// </summary>
    /// <param name="item"></param>
    private void DisableChildGO()
    {
        for (int i = 0; i < childGO.Count; i++)
        {
            childGO[i].SetActive(false);
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
            currentLifeTime = lifeTimeInspector; // reset lifeTime
            gameObject.SetActive(false); // disabling bonus
        }
    }

    /// <summary>
    /// Sets new random bonus when plaer hits bonus
    /// </summary>
    void SetOnDestroy() 
    {
        randomChild = childGO[Random.Range(0, childGO.Count - 1)];
        ChildGO = randomChild;
    }

    public void GroundedON()
    {
        grounded = true;
        agent.speed = currentSpeed;
    }

    /// <summary>
    /// method to freeze all object ob location
    /// </summary>
    public void FreezeAll()
    {
       agent.speed = 0;
       StartCoroutine(FreezeTime(freezeTime));
    }

    IEnumerator FreezeTime(float freezeTime) 
    {
        yield return new WaitForSeconds(freezeTime);
        agent.speed = currentSpeed;
    }


}

