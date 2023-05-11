using UnityEngine;

public class BonusFreezeAll : MonoBehaviour, IGetBonus
{
    public void GetBonus()
    {
        Actions.freezeAll();
    }
}
