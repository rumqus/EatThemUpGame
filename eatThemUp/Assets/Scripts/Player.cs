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
    private void ChangeSize(Vector3 colObject) 
    {
        sizeOfPlayer += colObject;
        transform.localScale = sizeOfPlayer;
        transform.position = Vector3.Lerp(transform.position, transform.position + stepPosition, speedGrowth * Time.deltaTime);
       
    }


    private void OnTriggerEnter(Collider other)
    {
        if (CompareSize(other.gameObject))
        {
            ChangeSize(other.transform.localScale);
            Destroy(other.gameObject);
        }
        else 
        {
            Debug.Log("Конец игры");
        //жрем игрока
        //отыгрываем анимацию пожирания
        //удаялем игрока
        // закачиваем игру
        }
        
    }

    /// <summary>
    /// метод сравнения размеров сталкиваемых объектов
    /// </summary>
    /// <param name="collidedObject"></param>
    /// <returns></returns>
    public bool CompareSize(GameObject collidedObject)
    {
        if (sizeOfPlayer.x > collidedObject.transform.localScale.x)
        {
            return true;
        }
        else return false;
    
    }
    

}
