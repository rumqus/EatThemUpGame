using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GroundCollision : MonoBehaviour
{

    [SerializeField] GameObject enemy;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            enemy.GetComponent<Enemy>().grounded = true;
            enemy.GetComponent<NavMeshAgent>().enabled = true;

        }
    }
}
