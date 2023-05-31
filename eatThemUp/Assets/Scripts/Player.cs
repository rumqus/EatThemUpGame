using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEditor.Animations;

public class Player : MonoBehaviour
{
    private float pointsSize; // points of size Player
    private int levelOfSize; // level of Size player
    [SerializeField] private int maxLevelofSize; // max level of size
    private Vector3 stepPosition = new Vector3(0, 1f, 0f); // step of changing player position against Y axis
    [SerializeField] private float speedGrowth; // speed of growth Player
    [SerializeField] private float stepSize; // step of increasing size player
    [SerializeField] private float timer;
    private bool onOffSuperSize;
    private Dictionary<int, string> dic;
    private int randomTime;


    public float PointSize { get { return pointsSize; } private set { pointsSize = value; } }
    public int LevelOfsize { get { return levelOfSize; } private set { levelOfSize = value; } }

    // Start is called before the first frame update
    void Start()
    {
        pointsSize = 1f;
        levelOfSize = 1;
        onOffSuperSize = false;
        dic = new Dictionary<int, string> { { 0, "smallEnemy" }, { 1, "mediumEnemy" }, { 2, "bigEnemy" }, { 3, "coin" }, { 4, "bonus" } };
    }

    // Update is called once per frame
    void Update()
    {
        CheckSuperSize(onOffSuperSize);
        randomTime = Random.Range(3, 8);
    }

    /// <summary>
    /// Changing size of Player
    /// </summary>
    private bool ChangeSize(float enemySize, float enemyLevel)
    {
        pointsSize += enemySize; //прибавляем очки роста
        if (pointsSize / 3 > 1)
        {
            if (levelOfSize < maxLevelofSize)
            {
                Vector3 newScale = transform.localScale + new Vector3(stepSize, stepSize, stepSize);
                levelOfSize++;
                transform.position = Vector3.Lerp(transform.position, transform.position + stepPosition, speedGrowth * Time.deltaTime);
                pointsSize = 1f;
            }
            else
            {
                GetSuperSize();
            }
        }
        return true;
    }

    /// <summary>
    /// returning an object to its initial state
    /// </summary>
    /// <param name="enemy"></param>
    private void ResetEnemy(GameObject enemy)
    {
        enemy.GetComponent<NavMeshAgent>().enabled = false;
        enemy.GetComponent<Rigidbody>().isKinematic = false;
        enemy.GetComponent<Enemy>().grounded = false;
    }

    private void ResetBonus(GameObject bonus) 
    {
        bonus.GetComponent<NavMeshAgent>().enabled = false;
        bonus.GetComponent<Rigidbody>().isKinematic = false;
        bonus.GetComponent<Bonus>().grounded = false;
    }


    private void OnTriggerEnter(Collider other)
    {

        // невероятно монструозная херня
        // detecting collision with enemy
        if (other.TryGetComponent<Enemy>(out Enemy enemy))
        {
            // compare size with player vs enemy
            if (CompareSizeLevel(enemy.LevelofSize))
            {
                //if true - player is bigger
                if (ChangeSize(enemy.Size, enemy.LevelofSize))
                {
                    ResetEnemy(other.gameObject);
                    other.gameObject.SetActive(false);
                    {
                        foreach (var item in dic) // detecting what object was eated
                        {
                            if (item.Value == other.gameObject.tag) // if tag of dictionary compare with of eated object
                            {
                                StartCoroutine(DelaySpawn(2, ObjectPooler.SharedInstance.GetAllPooledObjects(item.Key), 1));
                            }
                        }
                        Actions.SumPoint();
                        Actions.Debug(pointsSize.ToString(), levelOfSize.ToString(), enemy.Size.ToString(), enemy.LevelofSize.ToString(), onOffSuperSize.ToString());
                    }
                }
            }
            else
            {
                // end of the games
                Debug.Log("Конец игры");
                //жрем игрока
                //отыгрываем анимацию пожирания
                //удаялем игрока
                // закачиваем игру
            }
        }
        if (other.TryGetComponent<Bonus>(out Bonus bonus))
        {
            foreach (GameObject child in bonus.ChildrenGO) 
            {
                if (child.activeInHierarchy == true)
                {
                    child.GetComponent<IGetBonus>().GetBonus();
                }
            }
            ResetBonus(other.gameObject);
            other.gameObject.SetActive(false);
            

        }
    }

    /// <summary>
    /// метод сравнения размеров сталкиваемых объектов
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
    /// player get super size to eat biggest enemy, переделать что бы игрок уменьшался в изначальное состояние
    /// </summary>
    private void GetSuperSize()
    {
        onOffSuperSize = true;
        levelOfSize = 10;
        StartCoroutine(TimeSuperSize(timer));
    }
    private IEnumerator TimeSuperSize(float timer)
    {
        yield return new WaitForSeconds(timer);
        pointsSize = 1f;
        levelOfSize = 1;
        onOffSuperSize = false;
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
        for (float time = 0; time < 2; time += Time.deltaTime)
        {
            transform.localScale = Vector3.Lerp(startScale, endScale, speedGrowth * Time.deltaTime);
        }
    }
    private void CheckSuperSize(bool onSize)
    {
        if (onSize == true)
        {
            SmoothScale(transform.localScale, new Vector3(1.5f, 1.5f, 1.5f));
        }
        else
        {
            SmoothScale(transform.localScale, new Vector3(1, 1, 1));
        }
    }

    IEnumerator DelaySpawn(int seconds, List<GameObject> listEnemys, int number)
    {
        yield return new WaitForSeconds(seconds);
        Actions.RespawnEnemy(listEnemys, 1);
        yield return new WaitForSeconds(seconds + seconds);
        Actions.DisableObjects(listEnemys, PooledObjects.LOCATION);
    }




}
