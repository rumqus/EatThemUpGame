using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BigEnemy : Enemy, IFreezeAll, IGrounded
{

    [SerializeField] private GameObject alert;
    [SerializeField] private Animator animController;
    [SerializeField] private NavMeshAgent itemAgent;
    [SerializeField] private GameObject canvas;
    private GameObject freezeCanvas;
    private float currentSpeed;
    [SerializeField] private float currentLifeTime;
    private float lifeTime;
    [SerializeField] private Rigidbody rigidBody;

    private void Awake()
    {
        freezeCanvas = canvas;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = 5f;
        LevelofSize = 6f;
        Agent = gameObject.GetComponent<NavMeshAgent>();
        target = PlayerInstance.instancePlayer.player.transform;
        Agent.avoidancePriority = Random.Range(76, 99);
        freezeCanvas.SetActive(false);
        lifeTime = currentLifeTime;
    }

    private void OnEnable()
    {
        animController.enabled = true;
        freezeCanvas.SetActive(false);
        lifeTime = currentLifeTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Agent.speed != 0) // checking if object is freezed or not
        {
            ChasePlayer();
            MoveEnemy();
        }
        DisableObject();
    }

    /// <summary>
    /// method to freeze all objects on location
    /// </summary>
    public void FreezeAll()
    {
        Agent.speed = 0;
        Agent.enabled = false;
        animController.enabled = false;
        freezeCanvas.SetActive(true);
        StartCoroutine(FreezeTime(PooledObjects.FREEZETIME));
    }

    IEnumerator FreezeTime(float freezeTime)
    {
        yield return new WaitForSeconds(freezeTime);
        Agent.enabled = true;
        animController.enabled = true;
        freezeCanvas.SetActive(false);
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

    /// <summary>
    /// Disabling object when life time is over
    /// </summary>
    private void DisableObject()
    {
        lifeTime = lifeTime - Time.deltaTime;
        if (lifeTime <= 0)
        {
            Agent.enabled = false;
            rigidBody.isKinematic = false;
            grounded = false;
            lifeTime = currentLifeTime; // reset lifeTime
            Actions.SpawnOneItem(gameObject);
            gameObject.SetActive(false); // disabling bonus
        }
    }

    IEnumerator DelaySpawn(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Actions.SpawnOneItem(gameObject);
    }
}
