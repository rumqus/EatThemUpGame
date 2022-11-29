using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private float size; // ���� ����� ����������

    public float Size { get; protected set;}

    
    void Start()
    {
        
    }

    /// <summary>
    /// ����� ����������� ���������� �� �����
    /// </summary>
    public abstract void MoveEnemy();
        
}






