using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private float size; // очки роста противника

    public float Size { get; protected set;}

    
    void Start()
    {
        
    }

    /// <summary>
    /// метож перемещения противника по карте
    /// </summary>
    public abstract void MoveEnemy();
        
}






