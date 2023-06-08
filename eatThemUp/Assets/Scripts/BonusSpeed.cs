using UnityEngine;


public class BonusSpeed : MonoBehaviour, IGetBonus
{

    [SerializeField] float speedBonusTime;

    public void GetBonus()
    {
        Actions.bonusSpeed(speedBonusTime);

    }
}
