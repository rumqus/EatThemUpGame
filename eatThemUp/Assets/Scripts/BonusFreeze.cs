using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BonusFreeze : Bonus, IGetBonus
{

    [SerializeField] float freezeTime;

    private void Start()
    {
        Agent = GetComponentInParent<Bonus>().Agent;
    }

    public void Getbonus()
    {
        Actions.freezeBonus(freezeTime);
    }
}
