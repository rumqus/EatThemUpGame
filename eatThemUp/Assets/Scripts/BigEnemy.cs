using UnityEngine;

public class BigEnemy : Enemy
{
    public override void MoveEnemy()
    {
        Debug.Log("маленький враг двигается");
    }

    // Start is called before the first frame update
    void Start()
    {
        Size = 2f;
    }
        
}
