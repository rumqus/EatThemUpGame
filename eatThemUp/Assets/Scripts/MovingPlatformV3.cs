using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformV3 : MonoBehaviour
{
    [SerializeField] private List<Transform> waypoints;
    [SerializeField] private GameObject movingPlatform;
    private float moveSpeed;
    private GameObject player;
    private int currentWaypoint;
    private Vector3 originalScale;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Start is called before the first frame update
    private void Start()
    {
        moveSpeed = Random.Range(2, 5);
        originalScale = player.transform.localScale;
        if (waypoints.Count <= 0) return;
        currentWaypoint = 0;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {

        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypoint].transform.position,
            (moveSpeed * Time.deltaTime));

        if (Vector3.Distance(waypoints[currentWaypoint].transform.position, transform.position) <= 0.03)
        {
            currentWaypoint++;
        }

        if (currentWaypoint != waypoints.Count) return;
        waypoints.Reverse();
        currentWaypoint = 0;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.transform.SetParent(movingPlatform.transform);
            player.transform.localScale = originalScale;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            player.transform.parent = null;
        }
        
    }
}
