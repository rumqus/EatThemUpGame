using UnityEngine;

public class BigEnemy : Enemy
{
    public override void MoveEnemy()
    {
        Debug.Log("��������� ���� ���������");
    }

    // Start is called before the first frame update
    void Start()
    {
        Size = 2f;
    }
        
}
