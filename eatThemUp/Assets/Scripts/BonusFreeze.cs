using UnityEngine;


public class BonusFreeze : MonoBehaviour, IGetBonus
{

    [SerializeField] float freezeTime;

    public void GetBonus()
    {
        Actions.freezeBonus(freezeTime);
    }
}
