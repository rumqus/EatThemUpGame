using UnityEngine;
using UnityEngine.AI;

public class SmallEnemy : Enemy
{

    public override void MoveEnemy()
    {
        Debug.Log("маленький враг двигается");
    }

    // Start is called before the first frame update
    void Start()
    {

        Size = 0.25f;
        LevelofSize = 0.25f;
        Agent = gameObject.GetComponent<NavMeshAgent>();
        Debug.Log(Agent.isActiveAndEnabled);
        target = PlayerInstance.instancePlayer.player.transform;
        
    }

    private void Update()
    {
        CheckDistance();
    }

    //private void CheckDistance() 
    //{
    //    float distance = Vector3.Distance(target.position, transform.position);
    //    if (distance < 5f)
    //    {
    //        Agent.SetDestination(target.position);

    //    }

    //}
}
