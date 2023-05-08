using UnityEngine;


public class BonusSpeed : MonoBehaviour, IGetBonus
{

    [SerializeField] float speedBonus;

    public void GetBonus()
    {
        Actions.bonusSpeed(speedBonus);
    }
}
