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
        Actions.startZeropoints += ZeroPoints;
    }

    private void OnDisable()
    {
        Actions.SumPoint -= SumPoints;
        Actions.startZeropoints -= ZeroPoints;
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

    private void ZeroPoints() 
    {
        eatPoints = 0;
        eatPointsLabel.text = eatPoints.ToString();
    }
    
}
