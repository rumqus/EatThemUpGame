using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private List<Transform> waypoints = new List<Transform>();
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject movingPlatform;
    private Transform wayPointUp;
    private Transform wayPointDown;
    private int currentWaypoint;
    [SerializeField] Vector3 step;

    // Start is called before the first frame update
    void Start()
    {
        wayPointDown = movingPlatform.transform;
        wayPointUp = movingPlatform.transform;
        wayPointUp.position = new Vector3(0,5,0);
        wayPointDown.position = new Vector3(0, -5, 0);
        waypoints.Add(wayPointUp);
        waypoints.Add(wayPointDown);

        if (waypoints.Count <= 0) return;
        currentWaypoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlatform();
    }

    void MovePlatform()
    {
        movingPlatform.transform.position = Vector3.MoveTowards(movingPlatform.transform.position, waypoints[currentWaypoint].transform.position,
            (moveSpeed * Time.deltaTime));

        if (Vector3.Distance(waypoints[currentWaypoint].transform.position, transform.position) <= 0)
        {
            currentWaypoint++;
        }

        if (currentWaypoint != waypoints.Count) return;
        waypoints.Reverse();
        currentWaypoint = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        player.transform.parent = movingPlatform.transform;
            //transform.parent = transform;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        player.transform.parent = null;
    }
}
