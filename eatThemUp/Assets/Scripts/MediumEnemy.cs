using UnityEngine;

public class MediumEnemy : Enemy
{
    public override void MoveEnemy()
    {
        Debug.Log("��������� ���� ���������");
    }

    // Start is called before the first frame update
    void Start()
    {
        Size = 0.5f;
        LevelofSize = 0.5f;
    }
        
}
