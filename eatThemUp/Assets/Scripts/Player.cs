using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float pointsSize; // очки размера игрока
    private int LevelOfSize; // уровень размера игрока
    private Vector3 stepPosition = new Vector3(0, 1f, 0f); // шаг изменения позиции по Y при увелечении размера
    [SerializeField] private float speedGrowth = 2;
    [SerializeField] private float stepSize = 0.3f; // шаг увеличения размера


    // Start is called before the first frame update
    void Start()
    {
        pointsSize = 1f;
        LevelOfSize = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// метод изменения размера игрока
    /// </summary>
    private void ChangeSize(Enemy enemySize) 
    {
        pointsSize += enemySize.Size; //прибавляем очки роста
        if (LevelOfSize <= 5 && pointsSize/5 >= 1)
        {
            LevelOfSize++;
            transform.localScale += new Vector3(stepSize, stepSize, stepSize);
            transform.position = Vector3.Lerp(transform.position, transform.position + stepPosition, speedGrowth * Time.deltaTime);
        }
        else 
        {
         // даем увеличение на время
        }
        
        
       
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(TryGetComponent(out Enemy comps));
        if (TryGetComponent(out Enemy comp))
        {
            if (CompareSize(comp.Size))
            {
                ChangeSize(comp);
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

        
        
    }

    /// <summary>
    /// метод сравнения размеров сталкиваемых объектов
    /// </summary>
    /// <param name="collidedObject"></param>
    /// <returns></returns>
    public bool CompareSize(float enemySize)
    {
        if (pointsSize > enemySize)
        {            
            return true;
        }
        else return false;
    
    }
    

}
