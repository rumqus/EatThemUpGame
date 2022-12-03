using UnityEngine;
using UnityEngine.UI;

public class DebugPanel : MonoBehaviour
{
    [SerializeField] private Text SizePlayer;
    [SerializeField] private Text LevelPlayer;
    [SerializeField] private Text SizeEnemy;
    [SerializeField] private Text LevelEnemy;
    [SerializeField] private GameObject player;

    public void Showdata() 
    {
        LevelPlayer.text = player.GetComponent<Player>().LevelOfsize.ToString();
        SizePlayer.text = player.GetComponent<Player>().PointSize.ToString();
        SizeEnemy.text = player.GetComponent<Player>().enemySizeS.ToString();
        LevelEnemy.text = player.GetComponent<Player>().enemyLevelS.ToString();

        
    }
}
