using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstance : MonoBehaviour
{
    public static PlayerInstance instancePlayer;
    public GameObject player;

    private void Awake()
    {
        instancePlayer = this;
    }
}
