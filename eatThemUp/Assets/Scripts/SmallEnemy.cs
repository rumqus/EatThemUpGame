using UnityEngine;

public class SmallEnemy : Enemy
{
    public override void MoveEnemy()
    {
        Debug.Log("��������� ���� ���������");
    }

    // Start is called before the first frame update
    void Start()
    {
        Size = 0.25f;
    }
        
}
