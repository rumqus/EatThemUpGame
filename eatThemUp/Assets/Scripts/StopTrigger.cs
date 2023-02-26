using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (TryGetComponent<PlayerMovement>(out PlayerMovement player))
        {
            other.attachedRigidbody.velocity = Vector3.zero;
        }
    }
}
