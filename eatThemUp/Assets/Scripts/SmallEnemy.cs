using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SmallEnemy : Enemy, IFreezeAll, IGrounded
{

    [SerializeField] private Animator enemyAnimator;
    private float currentSpeed;
    [SerializeField] GameObject canvas;
    private GameObject freezeCanvas;
    [SerializeField] GameObject participleDust;
    private GameObject participles;
    [SerializeField] private float currentLifeTime;
    [SerializeField] private Rigidbody rigidBody;
    private float lifeTime;
    [SerializeField] private PooledObjects pooledobj;
    private List<GameObject> enemys;
    [SerializeField] private float growthSpeed;
    bool small;
    Vector3 currentScale = new Vector3(1,1,1);


    
    //[SerializeField] private AudioSource deathSound;

    private void Awake()
    {
        freezeCanvas = canvas;
        participles = participleDust;
        small = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = 8f;
        Agent = gameObject.GetComponent<NavMeshAgent>();
        target = PlayerInstance.instancePlayer.player.transform;
        Agent.avoidancePriority = Random.Range(25, 73);
        Size = Random.Range(0.25f, 0.4f);
        freezeCanvas.SetActive(false);
        participleDust.SetActive(false);
        lifeTime = currentLifeTime;
        if (gameObject.tag == "smallEnemy")
        {
            enemys = ObjectPooler.SharedInstance.GetAllPooledObjects(0);
        }
        else
        {
            enemys = ObjectPooler.SharedInstance.GetAllPooledObjects(1);
        }
    }

    private void Update()
    {
        if (Agent.speed != 0)
        {
            ChasePlayer();
            MoveEnemy();
        }
        DisableObject();
        SmoothScale(transform.localScale, new Vector3(0,0,0));
    }

    private void OnEnable()
    {
        enemyAnimator.enabled = true;
        freezeCanvas.SetActive(false);
        participles.SetActive(true);
        lifeTime = currentLifeTime;
        rigidBody.velocity = Vector3.zero;
    }

    /// <summary>
    /// method to freeze all object ob location
    /// </summary>
    public void FreezeAll()
    {
        Agent.speed = 0;
        Agent.enabled = false;
        enemyAnimator.enabled = false;
        freezeCanvas.SetActive(true);
        StartCoroutine(FreezeTime(PooledObjects.FREEZETIME));
    }

    IEnumerator FreezeTime(float freezeTime)
    {
        yield return new WaitForSeconds(freezeTime);
        Agent.enabled = true;
        enemyAnimator.enabled = true;
        freezeCanvas.SetActive(false);
        Agent.speed = currentSpeed;
    }

    /// <summary>
    /// checking grounded
    /// </summary>
    public void GroundedON()
    {
        grounded = true;
        Agent.speed = currentSpeed;
        participles.SetActive(true);
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
        if (lifeTime <= 4)
        {
            small = true;
        }

        IEnumerator DelaySoundDeath()
        {
            yield return new WaitForSeconds(0.2f);
            Agent.enabled = false;
            rigidBody.isKinematic = false;
            grounded = false;
            transform.localScale = currentScale;
            small = false;
            Actions.SpawnOneItem(enemys);
            lifeTime = currentLifeTime; // reset lifeTime
            gameObject.SetActive(false); // disabling bonus
        }
    }

    private void SmoothScale(Vector3 currentsize, Vector3 newSize)
    {
        if (small)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, newSize, growthSpeed * Time.deltaTime);
        }
    }

}
