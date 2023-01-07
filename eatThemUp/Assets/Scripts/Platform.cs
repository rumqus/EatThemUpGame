using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private Player player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            Debug.Log("triger in_1");
            other.gameObject.transform.SetParent(gameObject.transform.parent);
            Debug.Log("triger in_2");
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("triger out_1");
        if (other.TryGetComponent<Player>(out Player player))
        {
            other.gameObject.transform.parent = null;
            Debug.Log("triger out_2");
        }
    }
}
