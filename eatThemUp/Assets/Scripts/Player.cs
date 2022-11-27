using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] static float size; // текущий уровень размер игрока
    private Vector3 sizeOfPlayer; // текущий размер игрока
    [SerializeField] private Vector3 plusSize = new Vector3(0.05f, 0.05f,0.05f); //шаг увелечения размера игрока
    private Vector3 stepPosition = new Vector3(0, 1f, 0f); // шаг изменения позиции по Y при увелечении размера
    [SerializeField] private float speedGrowth = 2;

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
        transform.localScale = sizeOfPlayer;
        transform.position = Vector3.Lerp(transform.position, transform.position + stepPosition, speedGrowth * Time.deltaTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        ChangeSize();
        Destroy(other.gameObject);
        

    }


}
