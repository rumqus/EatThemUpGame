using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float pointsSize; // points of size Player
    private int levelOfSize; // level of Size player
    [SerializeField] private int maxLevelofSize; // max level of size
    private Vector3 stepPosition = new Vector3(0, 1f, 0f); // step of changing player position against Y axis
    [SerializeField] private float speedGrowth ; // speed of growth Player
    [SerializeField] private float stepSize; // step of increasing size player
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
       // DebugSmooth();
    }

    /// <summary>
    /// Changing size of Player
    /// </summary>
    private void ChangeSize(float enemySize, float enemyLevel)
    {
        pointsSize += enemySize; //прибавл€ем очки роста
        if (pointsSize / 3 > 1)
        {
            if (levelOfSize < maxLevelofSize)
            {
                Vector3 newScale = transform.localScale + new Vector3(stepSize, stepSize, stepSize);
                levelOfSize++;
                //SmoothScale(transform.localScale,newScale);
                transform.localScale = Vector3.Lerp(transform.localScale, newScale, speedGrowth); 
                transform.position = Vector3.Lerp(transform.position, transform.position + stepPosition, speedGrowth * Time.deltaTime);
                pointsSize = 1f;
            }
            else
            {
                GetSuperSize();
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
            if (CompareSizeLevel(enemy.LevelofSize))
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
    public bool CompareSizeLevel(float enemylevel)
    {
        if (levelOfSize > enemylevel)
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
        levelOfSize = 10;
        SmoothScale(transform.localScale, new Vector3(3f, 3f, 3f));
        //transform.localScale = new Vector3(3f, 3f, 3f);
        StartCoroutine(TimeSuperSize(timer));
    }

    private IEnumerator TimeSuperSize(float timer)
    {
        yield return new WaitForSeconds(timer);
        pointsSize = 1f;
        levelOfSize = 1;
        //transform.localScale = new Vector3(1f, 1f, 1f);
        SmoothScale(transform.localScale, new Vector3(1f, 1f, 1f));
    }

    /// <summary>
    /// smooth scale of player
    /// </summary>
    /// <param name="currentsize"></param>
    /// <param name="newSize"></param>
    private void SmoothScale(Vector3 currentsize, Vector3 newSize) 
    {
        transform.localScale = Vector3.Lerp(currentsize, newSize, speedGrowth);
    }

    private void DebugSmooth() 
    {
        if (Input.GetButton("Jump"))
        {
            SmoothScale(transform.localScale, new Vector3(5, 5, 5));
        }
        else 
        {
            SmoothScale(transform.localScale, new Vector3(1, 1, 1));
        }
    }


}
