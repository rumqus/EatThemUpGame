using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class SmallEnemy : Enemy, IFreezeAll, IGrounded
{

    [SerializeField] private Animator enemyAnimator;
    private float currentSpeed;

    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = 8f;
        Agent = gameObject.GetComponent<NavMeshAgent>();
        target = PlayerInstance.instancePlayer.player.transform;
        Agent.avoidancePriority = Random.Range(25, 73);
        Size = Random.Range(0.25f,0.4f);
    }

    private void Update()
    {
       ChasePlayer();
       MoveEnemy();
    }

    private void OnEnable()
    {
        enemyAnimator.enabled = true;

    }

    /// <summary>
    /// method to freeze all object ob location
    /// </summary>
    public void FreezeAll()
    {
        Agent.speed = 0;
        enemyAnimator.enabled = false;
        StartCoroutine(FreezeTime(PooledObjects.FREEZETIME));
    }

    IEnumerator FreezeTime(float freezeTime)
    {
        yield return new WaitForSeconds(freezeTime);
        enemyAnimator.enabled = true;
        Agent.speed = currentSpeed;
    }

    public void GroundedON()
    {
        grounded = true;
        Agent.speed = currentSpeed;
    }


}
