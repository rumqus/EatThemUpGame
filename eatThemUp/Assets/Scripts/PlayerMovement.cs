using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Rigidbody playerRb;
    [SerializeField] private GameObject player;
    [SerializeField] AnimateController animate;
    private Vector3 movement;
    bool invert = false;

    private void OnEnable()
    {
        Actions.bonusSpeed += GetSpeedBonus;
        Actions.freezeBonus += GetFreezeBonus;
        Actions.invertBonus += GetInvertMoveBonus;
    }

    private void OnDisable()
    {
        Actions.bonusSpeed -= GetSpeedBonus;
        Actions.freezeBonus -= GetFreezeBonus;
        Actions.invertBonus -= GetInvertMoveBonus;
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        ChangeAnimState();
        
    }

    private void FixedUpdate()
    {
        MovePlayer();
        transform.LookAt(playerRb.position + movement);

    }
    /// <summary>
    /// moving player
    /// </summary>
    private void MovePlayer() 
    {
        playerRb.MovePosition(playerRb.position + movement.normalized * speed * Time.deltaTime);
        
        
    }
    /// <summary>
    /// get input from player
    /// </summary>
    private void GetInput() 
    {
        if (invert)
        {
            movement.x = Input.GetAxisRaw("Horizontal") * -1;
            movement.z = Input.GetAxisRaw("Vertical") * -1;
        }
        else 
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.z = Input.GetAxisRaw("Vertical");

        }



    }

    /// <summary>
    /// method of getting boost to speed of the player
    /// </summary>
    /// <param name="speedBonus"></param>
    private void GetSpeedBonus(float speedBonus)
    {
        speed = speed + speedBonus;
    }

    /// <summary>
    /// bonus that freezing player over timer
    /// </summary>
    /// <param name="freezeTime"></param>
    private void GetFreezeBonus(float freezeTime)
    {
        float currentSpeed = speed;
        speed = 0;
        gameObject.GetComponent<AnimateController>().enabled = false;
        StartCoroutine(waitTime(freezeTime));
        
        IEnumerator waitTime(float time)
        {
            yield return new WaitForSeconds(time);
            speed = currentSpeed;
            gameObject.GetComponent<AnimateController>().enabled = true;
        }

    }

    /// <summary>
    /// method of inverting controls of the player
    /// </summary>
    /// <param name="invertTime"></param>
    private void GetInvertMoveBonus(float invertTime)
    {
        invert = true;
        StartCoroutine(waitTime(invertTime));

        IEnumerator waitTime(float time)
        {
            yield return new WaitForSeconds(time);
            invert = false;

        }

    }

    /// <summary>
    /// accessing animator on player to change animation state 
    /// </summary>
    private void ChangeAnimState() 
    {
        if (movement.x == 0 && movement.z == 0)
        {
            animate.SetBool("run", false);
        }
        else 
        {
            animate.SetBool("run", true);
        }
       
    }
   
}
