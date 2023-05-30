using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GroundCollision : MonoBehaviour
{

    [SerializeField] GameObject item;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            item.GetComponent<IGrounded>().GroundedON();
            item.GetComponent<NavMeshAgent>().enabled = true;
        }
    }
}
