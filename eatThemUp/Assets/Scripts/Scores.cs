using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Scores : MonoBehaviour
{
    private int eatPoints;
    [SerializeField] private Text eatPointsLabel;

    private void OnEnable()
    {
        Actions.SumPoint += SumPoints;
    }

    private void OnDisable()
    {
        Actions.SumPoint -= SumPoints;
    }

    private void Start()
    {
        eatPoints = 0; 
    }

    void SumPoints() 
    {
        eatPoints = eatPoints + 1;
        eatPointsLabel.text = eatPoints.ToString();
    }
}
