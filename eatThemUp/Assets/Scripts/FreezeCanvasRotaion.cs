using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeCanvasRotaion : MonoBehaviour
{

    [SerializeField] GameObject parent;


    // Update is called once per frame
    void Update()
    {
        transform.rotation = parent.transform.rotation;
    }
}
