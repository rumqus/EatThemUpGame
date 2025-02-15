using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            Actions.EndGame();
        }
        else if (other.TryGetComponent<IDisableObject>(out IDisableObject item))
        {
            item.DisableObject();
        }
    }
}
