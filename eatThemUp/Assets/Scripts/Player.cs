using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float pointsSize; // points of size Player
    private int levelOfSize; // level of Size player
    [SerializeField] private int maxLevelofSize; // max level of size
    private Vector3 stepPosition = new Vector3(0, 1f, 0f); // step of changing player position against Y axis
    [SerializeField] private float speedGrowth = 2; // speed of growth Player
    [SerializeField] private float stepSize = 0.3f; // step of increasing size player
    [SerializeField] private float timer;

    // debug panel
    public float enemySizeS;
    public float enemyLevelS;
    public GameObject debugPanel;

    public float PointSize { get { return pointsSize; } private set { pointsSize = value; } }
    public int LevelOfsize { get { return levelOfSize; } private set { levelOfSize = value; } }

    // Start is called before the first frame update
    void Start()
    {
        pointsSize = 1f;
        levelOfSize = 1;

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Changing size of Player
    /// </summary>
    private void ChangeSize(float enemySize, float enemyLevel)
    {
        pointsSize += enemySize; //прибавл€ем очки роста

        //if (levelOfSize <= maxLevelofSize && pointsSize / 5 >= 1 && levelOfSize > enemyLevel)
        //{
        //    levelOfSize++;
        //    transform.localScale += new Vector3(stepSize, stepSize, stepSize);
        //    transform.position = Vector3.Lerp(transform.position, transform.position + stepPosition, speedGrowth * Time.deltaTime);
        //    pointsSize = 1f;
        //}
        //else if (levelOfSize == maxLevelofSize && pointsSize / 5 >= 1 && levelOfSize > enemyLevel)
        //{
        //    GetSuperSize();
        //}

        if (LevelOfsize > enemyLevel)
        {
            if (pointsSize / 5 > 1)
            {
                if (levelOfSize < maxLevelofSize)
                {
                    levelOfSize++;
                    transform.localScale += new Vector3(stepSize, stepSize, stepSize);
                    transform.position = Vector3.Lerp(transform.position, transform.position + stepPosition, speedGrowth * Time.deltaTime);
                    pointsSize = 1f;
                }
                else
                {
                    GetSuperSize();
                }

            }

        }

        enemyLevelS = enemyLevel;
        enemySizeS = enemySize;
        debugPanel.GetComponent<DebugPanel>().Showdata();

    }

    private void OnTriggerEnter(Collider other)
    {
        // detecting collision with enemy
        if (other.TryGetComponent<Enemy>(out Enemy enemy))
        {
            // compare size with player vs enemy
            if (CompareSize(enemy.Size))
            {
                //if true - player is bigger
                ChangeSize(enemy.Size, enemy.LevelofSize);
                Destroy(other.gameObject);
            }
            else
            {
                // end of the games
                Debug.Log(" онец игры");
                //жрем игрока
                //отыгрываем анимацию пожирани€
                //уда€лем игрока
                // закачиваем игру
            }

        }
    }

    /// <summary>
    /// метод сравнени€ размеров сталкиваемых объектов
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
    /// <summary>
    /// player get super size to eat biggest enemy, переделать что бы игрок уменьшалс€ в изначальное состо€ние
    /// </summary>
    private void GetSuperSize()
    {
        transform.localScale = new Vector3(3f, 3f, 3f);
        StartCoroutine(TimeSuperSize(timer));
    }

    private IEnumerator TimeSuperSize(float timer)
    {
        yield return new WaitForSeconds(timer);
        pointsSize = 1f;
        levelOfSize = 1;
        transform.localScale = new Vector3(1f, 1f, 1f);
    }



}
