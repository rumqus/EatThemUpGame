using UnityEngine;


public class BonusInvert : MonoBehaviour, IGetBonus
{
    //[SerializeField] private List<GameObject> childGO;
    //private GameObject randomChild;
    //[SerializeField] private float lifeTimeInspector;
    //private float currentLifeTime;
    [SerializeField] float invertTime;



    //void Start()
    //{

    //    Agent = gameObject.GetComponent<NavMeshAgent>();
    //    target = PlayerInstance.instancePlayer.player.transform;
    //    Agent.avoidancePriority = Random.Range(76, 99);
    //    Size = Random.Range(0.25f, 0.4f);
    //    currentLifeTime = lifeTimeInspector;
    //    SetRandomChildGo();
    //}

    //private void Update()
    //{
    //    MoveEnemy();
    //    DisableBonus();
    //}
    /// <summary>
    /// activating childGO
    /// </summary>
    //private void SetRandomChildGo()
    //{
    //    randomChild = childGO[Random.Range(0, childGO.Count - 1)];
    //    ChildGO = randomChild;
    //    randomChild.SetActive(true);
    //}
    /// <summary>
    /// disabling ChilGo
    /// </summary>
    /// <param name="item"></param>
    //public void DisableChildGO()
    //{
    //    for (int i = 0; i < childGO.Count; i++)
    //    {
    //        ChildGO.SetActive(false);
    //    }
    //}

    /// <summary>
    /// method of disabling bonus on over lifeTime, another timer(of spawning) in SpawnerV2.cs
    /// </summary>
    /// <param name="lifeTime"></param>
    //void DisableBonus()
    //{
    //    currentLifeTime = currentLifeTime - Time.deltaTime;
    //    if (currentLifeTime <= 0)
    //    {
    //        DisableChildGO();
    //        gameObject.GetComponent<NavMeshAgent>().enabled = false;
    //        gameObject.GetComponent<Rigidbody>().isKinematic = false;
    //        gameObject.GetComponent<Enemy>().grounded = false;
    //        gameObject.SetActive(false);
    //        SetRandomChildGo();
    //        currentLifeTime = lifeTimeInspector;
    //    }
    //}

    public void GetBonus()
    {
        Actions.invertBonus(invertTime);
    }
}
