using System;
using System.Collections.Generic;
using UnityEngine;


public class Actions : MonoBehaviour
{
    public static Action startZeropoints;
    public static Action<float> bonusSpeed;
    public static Action<float> freezeBonus;
    public static Action<float> invertBonus;
    public static Action freezeAll;
    public static Action setRandomBonus;
    public static Action<List<GameObject>,int> RespawnEnemy;
    public static Action<GameObject> SpawnOneItem;
    public static Action<List<GameObject>, int> DisableObjects;
    public static Action SumPoint;
    public static Action EndGame;
    public static Action<string> SfxPlay;
    public static Action SoundPause;
}
