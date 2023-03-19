using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]private List<Transform> waypoints = new List<Transform>();
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject movingPlatform;
    private int currentWaypoint;
    [SerializeField] Vector3 step;
    Vector3 originalScale;

    // Start is called before the first frame update
    void Start()
    {
        originalScale = player.transform.lossyScale;
        if (waypoints.Count <= 0) return;
        currentWaypoint = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovePlatform();
    }

    void MovePlatform()
    {
        movingPlatform.transform.position = Vector3.MoveTowards(movingPlatform.transform.position, waypoints[currentWaypoint].transform.position,
            (moveSpeed * Time.fixedDeltaTime));

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
        if (!other.gameObject.CompareTag("Player")) return;
        player.transform.SetParent(movingPlatform.transform);
        player.transform.localScale = originalScale;
        Debug.Log("collision start");
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        player.transform.parent = null;
        Debug.Log("collision exit");
    }
}
