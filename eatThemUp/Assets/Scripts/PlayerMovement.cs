using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Rigidbody playerRb;
    [SerializeField] private GameObject player;
    private Vector3 movement;
 
    // Update is called once per frame
    void Update()
    {
        GetInput();
        
    }

    private void FixedUpdate()
    {
        MovePlayer();
        transform.LookAt(playerRb.position + movement);

    }
    /// <summary>
    /// Метод передвижения игрока
    /// </summary>
    private void MovePlayer() 
    {
        playerRb.MovePosition(playerRb.position + movement.normalized * speed * Time.deltaTime);
        
        
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
