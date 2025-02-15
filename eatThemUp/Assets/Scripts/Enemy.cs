using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour, IGrounded
{
    [SerializeField] private float size; // points of size enemy
    [SerializeField] private int levelofSize; // Level of enemy
    protected float radius = 10f; // radius of enemy start acting
    protected Transform target; // target - player to chase and look
    protected NavMeshAgent agent;
    [SerializeField] protected float areaRadius; // radius enemy geting random point
    protected float timer; // time for movement
    [SerializeField] protected GameObject ChildGO;
    protected bool Up;
    protected Vector3 upPosition;
    public bool grounded;

    public float Size { get; protected set; }

    public float LevelofSize { get; protected set; }

    public NavMeshAgent Agent { get; protected set; }


    protected void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, areaRadius);
    }

    private void Start()
    {
        areaRadius = 50;
        grounded = false;
    }

    private void Update()
    {
        ChasePlayer();
    }

    /// <summary>
    /// random movement enemy on the map
    /// </summary>
    protected void MoveEnemy()
    {
        if (!Agent.hasPath && grounded == true)
        {
            GetComponent<Rigidbody>().isKinematic = true;
            Agent.SetDestination(GetPoint.Instance.GetRandomPoint(transform, areaRadius));
        }
    }

    /// <summary>
    /// checking distance between player and enemy
    /// </summary>
    protected void ChasePlayer()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance < radius && LevelofSize > target.GetComponent<Player>().LevelOfsize)
        {
            Agent.SetDestination(target.position);
            FaceToPlayer();
        }
        else
        {
            MoveEnemy();
        }
    }

    protected void FaceToPlayer()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    public void GroundedON()
    {
        grounded = true;
    }
}