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
    private List<GameObject> enemys;
    //[SerializeField] private AudioSource deathSound;

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
        enemys = ObjectPooler.SharedInstance.GetAllPooledObjects(3);
    }

    private void OnEnable()
    {
        animController.enabled = true;
        freezeCanvas.SetActive(false);
        lifeTime = currentLifeTime;
        rigidBody.velocity = Vector3.zero;
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
            //deathSound.Play();
            StartCoroutine(DelaySoundDeath());
        }

        IEnumerator DelaySoundDeath()
        {
            yield return new WaitForSeconds(0.2f);
            Agent.enabled = false;
            rigidBody.isKinematic = false;
            grounded = false;
            Actions.SpawnOneItem(enemys);
            lifeTime = currentLifeTime; // reset lifeTime
            gameObject.SetActive(false); // disabling bonus
        }
    }

}
