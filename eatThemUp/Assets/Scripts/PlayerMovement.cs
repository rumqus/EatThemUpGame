using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Rigidbody playerRb;
    private Vector3 movement;
    private float size; // размер игрока влияет на того кого может съесть
 
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }
    /// <summary>
    /// Метод передвижения игрока
    /// </summary>
    private void MovePlayer() 
    {
        playerRb.MovePosition(playerRb.position + movement * speed * Time.fixedDeltaTime);
    }
    /// <summary>
    /// метод получения ввода игрока
    /// </summary>
    private void GetInput() 
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");
    
    }

}
