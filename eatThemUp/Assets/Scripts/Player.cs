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
    private bool onOffSuperSize;
    

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
        onOffSuperSize = false;

    }

    // Update is called once per frame
    void Update()
    {
        CheckSuperSize(onOffSuperSize);
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
                //transform.localScale = Vector3.Lerp(transform.localScale, newScale, speedGrowth * Time.deltaTime); 
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
        onOffSuperSize = true;
        levelOfSize = 10;
        //DebugSmooth(transform.localScale, new Vector3(3, 3, 3));
        //SmoothScale(transform.localScale, new Vector3(3f, 3f, 3f));
        //transform.localScale = new Vector3(3f, 3f, 3f);
        
        StartCoroutine(TimeSuperSize(timer));
    }

    private IEnumerator TimeSuperSize(float timer)
    {
        yield return new WaitForSeconds(timer);
        pointsSize = 1f;
        levelOfSize = 1;
        onOffSuperSize = false;
        //transform.localScale = new Vector3(1f, 1f, 1f);
        //SmoothScale(transform.localScale, new Vector3(1f, 1f, 1f));
       
    }

    /// <summary>
    /// smooth scale of player
    /// </summary>
    /// <param name="currentsize"></param>
    /// <param name="newSize"></param>
    private void SmoothScale(Vector3 currentsize, Vector3 newSize) 
    {
        transform.localScale = Vector3.Lerp(transform.localScale, newSize, speedGrowth * Time.deltaTime);
    }

   


    private void DebugSmooth(Vector3 startScale, Vector3 endScale) 
    {
        for (float time = 0; time < 2; time +=Time.deltaTime)
        {
            transform.localScale = Vector3.Lerp(startScale,endScale, speedGrowth * Time.deltaTime);
        }
    }

    //IEnumerator ScaleUpAndDown(Transform transform, Vector3 upScale, float duration)
    //{
    //    Vector3 initialScale = transform.localScale;

    //    for (float time = 0; time < duration * 2; time += Time.deltaTime)
    //    {
    //        float progress = Mathf.PingPong(time, duration) / duration;
    //        transform.localScale = Vector3.Lerp(initialScale, upScale, progress);
    //        yield return null;
    //    }
    //    transform.localScale = initialScale;
    //}

    private void CheckSuperSize(bool onSize) 
    {
        if (onSize == true)
        {
            SmoothScale(transform.localScale, new Vector3(3, 3, 3));
        }
        else 
        {
            SmoothScale(transform.localScale, new Vector3(1, 1, 1));
        }
    
    }
}
