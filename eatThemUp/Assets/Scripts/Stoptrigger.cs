using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Stoptrigger : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {

            if (other.gameObject.tag == "Player")
            {

            other.gameObject.GetComponentInParent<NavMeshAgent>().enabled = true;
            }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            other.gameObject.GetComponentInParent<NavMeshAgent>().enabled = false;
        }

    }
}
