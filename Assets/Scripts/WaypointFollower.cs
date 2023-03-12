using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Move target to position of waypoints
public class WaypointFollower : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints;
    int currentWaypointIdx = 0;

    [SerializeField] float speed = 1f;

    void Start()
    {
            
    }

    void Update()
    {
        // Use 0.1f instead of 0 for floating points
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIdx].transform.position) < 0.1f) {
            currentWaypointIdx = (currentWaypointIdx + 1) % waypoints.Length;
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIdx].transform.position, speed * Time.deltaTime);
    }
}
