using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class SmallEnemy : Enemy, IFreezeAll
{
    private float currentSpeed;
    [SerializeField] private Animator enemyAnimator;
    [SerializeField] private NavMeshAgent enemyAgent;
// Start is called before the first frame update
    void Start()
    {
        Agent = gameObject.GetComponent<NavMeshAgent>();
        target = PlayerInstance.instancePlayer.player.transform;
        Agent.avoidancePriority = Random.Range(25, 73);
        Size = Random.Range(0.25f,0.4f);
        currentSpeed = GetComponent<NavMeshAgent>().speed;
    }

    private void Update()
    {
       ChasePlayer();
       MoveEnemy();
    }

    /// <summary>
    /// method to freeze all object ob location
    /// </summary>
    public void FreezeAll()
    {
        enemyAgent.speed = 0;
        enemyAnimator.enabled = false;
        StartCoroutine(FreezeTime(PooledObjects.FREEZETIME));
    }

    IEnumerator FreezeTime(float freezeTime)
    {
        yield return new WaitForSeconds(freezeTime);
        enemyAgent.speed = currentSpeed;
        enemyAnimator.enabled = true;
    }
}
