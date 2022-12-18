using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenLocation : MonoBehaviour
{
    [SerializeField] private int direction;
    private float rightStep = 75.2f;
    private Player player;
    [SerializeField] private GameObject manager;
    

    private void InstatinateLocation(int direction) 
    {
        
        if (direction == 1)
        {
            // gen top location
        }
        else if (direction == 2)
        {
            for (int i = 0; i < LocationList.locationInstance.pooledLocations.Count; i++)
            {
                if (LocationList.locationInstance.pooledLocations[i].active == false)
                {
                    GameObject newLocation = LocationList.locationInstance.pooledLocations[i];
                    newLocation.transform.position = new Vector3(GetComponentInParent<Transform>().position.x + rightStep, 0, 0);
                    newLocation.SetActive(true);
                    manager.transform.position = new Vector3(transform.position.x + rightStep,0,0);
                    break;
                }
            }
            //newLocation.transform.position = new Vector3(transform.position.x + rightStep, transform.position.y, transform.position.z);
        }
        else if (direction == 3)
        {
            // gen bottom location
        }
        else if (direction == 4)
        {
         // gen left location
        }

    
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("triger");
        if (other.TryGetComponent<Player>(out player))
        {
            
            InstatinateLocation(direction);
            
        }
    }

}
