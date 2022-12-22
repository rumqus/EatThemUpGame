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
    private Dictionary<int, string> dic;
    private int randomTime;

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
        dic = new Dictionary<int, string> {{ 0, "smallEnemy" },{ 1, "mediumEnemy"},{2, "bigEnemy"}};
    }

    // Update is called once per frame
    void Update()
    {
        CheckSuperSize(onOffSuperSize);
        randomTime = Random.Range(3,8);
    }

    /// <summary>
    /// Changing size of Player
    /// </summary>
    private bool ChangeSize(float enemySize, float enemyLevel)
    {
        pointsSize += enemySize; //���������� ���� �����
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

        enemyLevelS = enemyLevel;
        enemySizeS = enemySize;
        debugPanel.GetComponent<DebugPanel>().Showdata();
        return true;
    }

    private void OnTriggerEnter(Collider other)
    {
        // ���������� ������������ �����
        // detecting collision with enemy
        if (other.TryGetComponent<Enemy>(out Enemy enemy))
        {
            // checking if coin or not
            GetCoin(other.gameObject);

            // compare size with player vs enemy
            if (CompareSizeLevel(enemy.LevelofSize))
            {
                //if true - player is bigger
                if (ChangeSize(enemy.Size, enemy.LevelofSize))
                {
                    other.gameObject.SetActive(false);
                    RespawnEnemy(enemy.gameObject);
                }
            }
            else
            {
                // end of the games
                Debug.Log("����� ����");
                //���� ������
                //���������� �������� ���������
                //������� ������
                // ���������� ����
            }

        }
    }

    /// <summary>
    /// ����� ��������� �������� ������������ ��������
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
    /// player get super size to eat biggest enemy, ���������� ��� �� ����� ���������� � ����������� ���������
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

    private void GetCoin(GameObject other) 
    {
        if (other.tag == "coin")
        {
            Actions.SpawnCoin();
        }    
    }

    /// <summary>
    /// method - wrapping action
    /// </summary>
    /// <param name="enemy"></param>
    private void RespawnEnemy(GameObject enemy) 
    {
        foreach (var item in dic) 
        {
            if (enemy.tag == item.Value)
            {
                Actions.RespawnEnemy(2, ObjectPooler.SharedInstance.GetAllPooledObjects(item.Key));
                
            }
        }
    }

}
