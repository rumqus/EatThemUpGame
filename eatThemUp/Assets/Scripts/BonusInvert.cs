using UnityEngine;


public class BonusInvert : MonoBehaviour, IGetBonus
{

    [SerializeField] float invertTime;
    public void GetBonus()
    {
        Actions.invertBonus(invertTime);
        Actions.SfxPlay("invert");
    }
}
