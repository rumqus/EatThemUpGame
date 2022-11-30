using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private float size; // points of size enemy
    [SerializeField] private int levelofSize; // Level of enemy
    public float Size { get; protected set;}

    public float LevelofSize { get; protected set; }
    
    void Start()
    {
        
    }

    /// <summary>
    /// метож перемещения противника по карте
    /// </summary>
    public abstract void MoveEnemy();
        
}






