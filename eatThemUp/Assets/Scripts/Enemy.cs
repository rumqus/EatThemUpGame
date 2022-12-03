using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private float size; // points of size enemy
    [SerializeField] private int levelofSize; // Level of enemy
    private float radius = 5f; // radius of enemy start acting
    protected Transform target;
    protected NavMeshAgent agent;

    public float Size { get; protected set; }

    public float LevelofSize { get; protected set; }

    public NavMeshAgent Agent { get; protected set; }



    void Start()
    {
        
        Debug.Log($@"ENEMY { target.position}");
    }

    protected void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);

    }

    private void Update()
    {
        CheckDistance();
    }

    /// <summary>
    /// метож перемещения противника по карте
    /// </summary>
    public abstract void MoveEnemy();


    /// <summary>
    /// checking distance between player and enemy
    /// </summary>
    protected void CheckDistance() 
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance < radius)
        {
            Agent.SetDestination(target.position);

        }

    
    }
        
}






