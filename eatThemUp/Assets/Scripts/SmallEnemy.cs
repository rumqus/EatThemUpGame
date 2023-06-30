using System.Collections;
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


    private void Awake()
    {
        freezeCanvas = canvas;
        participles = participleDust;
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
        freezeCanvas.SetActive(false);
        participles.SetActive(true);
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


}
