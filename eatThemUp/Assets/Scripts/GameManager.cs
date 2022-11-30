using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text SizePlayer;
    [SerializeField] private Text LevelPlayer;
    [SerializeField] private Text SizeEnemy;
    [SerializeField] private Text LevelEnemy;
    [SerializeField] private GameObject player;

    private void Start()
    {
        
    }

    private void Update()
    {
        Showdata();
    }


    public void Showdata() 
    {
        SizePlayer.text = player.GetComponent<Player>().LevelOfsize.ToString();
        LevelPlayer.text = player.GetComponent<Player>().PointSize.ToString();
        SizeEnemy.text = player.GetComponent<Player>().enemySize.ToString();
        SizeEnemy.text = player.GetComponent<Player>().enemyLevel.ToString();

        Debug.Log(player.GetComponent<Player>().LevelOfsize.ToString());
    }
}
