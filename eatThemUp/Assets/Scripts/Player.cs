using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float pointsSize; // ���� ������� ������
    private int LevelOfSize; // ������� ������� ������
    private Vector3 stepPosition = new Vector3(0, 1f, 0f); // ��� ��������� ������� �� Y ��� ���������� �������
    [SerializeField] private float speedGrowth = 2;
    [SerializeField] private float stepSize = 0.3f; // ��� ���������� �������


    // Start is called before the first frame update
    void Start()
    {
        pointsSize = 1f;
        LevelOfSize = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// ����� ��������� ������� ������
    /// </summary>
    private void ChangeSize(Enemy enemySize) 
    {
        pointsSize += enemySize.Size; //���������� ���� �����
        if (LevelOfSize <= 5 && pointsSize/5 >= 1)
        {
            LevelOfSize++;
            transform.localScale += new Vector3(stepSize, stepSize, stepSize);
            transform.position = Vector3.Lerp(transform.position, transform.position + stepPosition, speedGrowth * Time.deltaTime);
        }
        else 
        {
         // ���� ���������� �� �����
        }
        
        
       
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(TryGetComponent(out Enemy comps));
        if (TryGetComponent(out Enemy comp))
        {
            if (CompareSize(comp.Size))
            {
                ChangeSize(comp);
                Destroy(other.gameObject);
            }
            else
            {
                Debug.Log("����� ����");
                //���� ������
                //���������� �������� ���������
                //������� ������
                // ���������� ����
            }

        }

        
        
    }

    /// <summary>
    /// ����� ��������� �������� ������������ ��������
    /// </summary>
    /// <param name="collidedObject"></param>
    /// <returns></returns>
    public bool CompareSize(float enemySize)
    {
        if (pointsSize > enemySize)
        {            
            return true;
        }
        else return false;
    
    }
    

}
