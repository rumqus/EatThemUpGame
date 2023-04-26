using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Scores : MonoBehaviour
{
    private int eatPoints;
    [SerializeField] private Text eatPointsLabel;

    private int coins;
    [SerializeField] private Text coinsLabel;

    private void OnEnable()
    {
        Actions.SumPoint += SumPoints;
        Actions.SumCoins += SumCoins;
    }

    private void OnDisable()
    {
        Actions.SumPoint -= SumPoints;
        Actions.SumCoins -= SumCoins;
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
}
