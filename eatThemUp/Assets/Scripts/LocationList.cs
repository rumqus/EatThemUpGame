using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationList : MonoBehaviour
{
    [SerializeField] private List<GameObject> locations; // all locations
    public List<GameObject> pooledLocations;
    
    public static LocationList locationInstance;
    

    private void Awake()
    {
        locationInstance = this;
    }

    private void Start()
    {
        for (int i = 0; i < locations.Count; i++)
        {
            GameObject newLocation = Instantiate(locations[i]);
            newLocation.SetActive(false);
            pooledLocations.Add(newLocation);
           
        }
    }
}
