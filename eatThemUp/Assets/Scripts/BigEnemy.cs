using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BigEnemy : Enemy, IFreezeAll, IGrounded
{

    [SerializeField] private GameObject alert;
    [SerializeField] private Animator animController;
    [SerializeField] private NavMeshAgent itemAgent;
    private float currentSpeed;
   

    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = 5f;
        LevelofSize = 6f;
        Agent = gameObject.GetComponent<NavMeshAgent>();
        target = PlayerInstance.instancePlayer.player.transform;
        Agent.avoidancePriority = Random.Range(76, 99);

    }

    private void OnEnable()
    {
        animController.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        ChasePlayer();
        MoveEnemy();
    }

    /// <summary>
    /// method to freeze all objects on location
    /// </summary>
    public void FreezeAll()
    {
        Agent.speed = 0;
        animController.enabled = false;
        StartCoroutine(FreezeTime(PooledObjects.FREEZETIME));
    }

    IEnumerator FreezeTime(float freezeTime)
    {
        yield return new WaitForSeconds(freezeTime);
        animController.enabled = true;
        Agent.speed = currentSpeed;
    }

    /// <summary>
    /// checking distance between player and enemy
    /// </summary>
    protected void ChasePlayer()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance < radius && LevelofSize > target.GetComponent<Player>().LevelOfsize)
        {
            alert.SetActive(true);
            Agent.SetDestination(target.position);
            FaceToPlayer();
        }
        else
        {
            alert.SetActive(false);
            MoveEnemy();
        }
    }

    public void GroundedON()
    {
        grounded = true;
        Agent.speed = currentSpeed;
    }

}
