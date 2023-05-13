using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateController : MonoBehaviour
{
    [SerializeField] Animator animator;

    public void SetBool(string name, bool state ) 
    {
        animator.SetBool(name, state);
    }

}
