using System;
using System.Collections.Generic;
using UnityEngine;


public class Actions : MonoBehaviour
{
    public static Action<float> bonusSpeed;
    public static Action<float> freezeBonus;
    public static Action<float> invertBonus;
    public static Action<List<GameObject>,int> RespawnEnemy;
    public static Action<GameObject> SpawnOneItem;
    public static Action<List<GameObject>, int> DisableObjects;
    public static Action SumPoint;
    public static Action SumCoins;
    public static Action<float> BoostPlayerSpeed;
    //public static Action<GameObject> DisableChildGO;
    public static Action<string, string, string, string, string> Debug; // Debug action - to see in game parametrs on hitting enemy
}
