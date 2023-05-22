using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertRotation : MonoBehaviour
{
    GameObject targetObject;

    private void Start()
    {
        targetObject = GameObject.FindGameObjectWithTag("camera");
    }

    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - targetObject.transform.position);
    }

}
