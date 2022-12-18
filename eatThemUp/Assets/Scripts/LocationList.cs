using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationList : MonoBehaviour
{
    [SerializeField]public List<GameObject> locations; // all locations
    
    public static LocationList locationInstance;

    private void Awake()
    {
        locationInstance = this;
    }


}
