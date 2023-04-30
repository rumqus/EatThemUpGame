using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Scores : MonoBehaviour
{
    private int eatPoints;
    [SerializeField] float bonus;
    [SerializeField] private Text eatPointsLabel;
    [SerializeField] private Text playerSize;
    [SerializeField] private Text playerLevel;
    [SerializeField] private Text enemyLevel;
    [SerializeField] private Text enemySize;
    [SerializeField] private Text superSize;


    private int coins;
    [SerializeField] private Text coinsLabel;

    private void OnEnable()
    {
        Actions.SumPoint += SumPoints;
        Actions.SumCoins += SumCoins;
        Actions.Debug += DebugPanel;
    }

    private void OnDisable()
    {
        Actions.SumPoint -= SumPoints;
        Actions.SumCoins -= SumCoins;
        Actions.Debug -= DebugPanel;
    }

    private void Start()
    {
        eatPoints = 0;
    }

    void SumPoints()
    {
        eatPoints++;
        eatPointsLabel.text = eatPoints.ToString();
    }

    void SumCoins()
    {
        coins++;
        coinsLabel.text = coins.ToString();
    }

    /// <summary>
    /// when player eats bonus, player boost speed on bonus
    /// </summary>
    /// <param name="speed"></param>
    /// <returns></returns>
    float CalculateSpeed(float speed)
    {
        speed = speed + bonus;
        return speed;
    }

    /// <summary>
    /// Debug Panel
    /// </summary>
    /// <param name="plpoints"></param>
    /// <param name="plLevel"></param>
    /// <param name="ePoints"></param>
    /// <param name="eLevel"></param>
    /// <param name="super"></param>
    void DebugPanel(string plpoints, string plLevel, string ePoints, string eLevel, string super) 
    {
        Debug.Log("Get data");
        playerSize.text = plpoints;
        playerLevel.text = plLevel;
        enemyLevel.text = eLevel;
        enemySize.text = ePoints;
        superSize.text = super;

    }
}
