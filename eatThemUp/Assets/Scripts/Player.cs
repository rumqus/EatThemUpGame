using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] static float size; // текущий уровень размер игрока
    private Vector3 sizeOfPlayer; // текущий размер игрока
    [SerializeField] private Vector3 plusSize = new Vector3(0.3f, 0.3f,0.3f); //шаг увелечения размера игрока

    // Start is called before the first frame update
    void Start()
    {
        size = 1f;
        sizeOfPlayer = GetComponent<Transform>().localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// метод изменения размера игрока
    /// </summary>
    private void ChangeSize() 
    {
        sizeOfPlayer += plusSize;
        gameObject.transform.localScale = sizeOfPlayer;
    }


    private void OnTriggerEnter(Collider other)
    {
        ChangeSize();
        
    }

}
