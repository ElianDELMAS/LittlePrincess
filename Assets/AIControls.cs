using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AIControls : MonoBehaviour
{
    private Vector2 input;
    public UnityEvent<Vector2> onInput;
    public bool frost;

    public CarIdentity identity;

    public Transform waypointsHolder;
    private List<Transform> waypoints;
    private Transform nextWaypoint;
    private Vector3 nextWaypointPosition;

    public float maxDistanceToTarget = 20f;
    public float maxDistanceToReverse = 40f;

    public float randomJitterOnPosition = 2f;

    void Awake()
    {
        // Initialize waypoints list by finding all Transform waypoints inside waypointsHolder
        this.waypoints = new List<Transform>();
        Transform[] result = this.waypointsHolder.GetComponentsInChildren<Transform>();
        for (int i = 1; i < result.Length; i++) { this.waypoints.Add(result[i]); }
    }

    void Start()
    {
        // Start with first waypoint
        SelectWaypoint(waypoints[0]);
    }

    void Update()
    {
        if (!this.frost)
        {
            // Change to next waypoint if reached current waypoint
            float distanceToTarget = Vector3.Distance(transform.position, nextWaypointPosition);
            //Debug.Log("Distance to target: " + distanceToTarget);
            if (distanceToTarget < maxDistanceToTarget)
            {
                int nextIndex = waypoints.IndexOf(nextWaypoint) + 1;
                SelectWaypoint(nextIndex < waypoints.Count ? waypoints[nextIndex] : waypoints[0]);
                //Debug.Log("Target changed to waypoint " + nextIndex);
                //Debug.Log("Next waypoint position = " + nextWaypointPosition);
            }

            // Compute Vector2 input based on distances in Right and Forward axis
            Vector3 diff = nextWaypointPosition - transform.position;
            //Debug.Log("diff = " + diff);
            float componentRight = Vector3.Dot(diff, transform.right.normalized); // input.x
            float componentForward = Vector3.Dot(diff, transform.forward.normalized); // input.y
            //Debug.Log("componentForward = " + componentForward + " | componentRight = " + componentRight);
            this.input = new Vector2(componentRight * (-1f), componentForward * (-1f)).normalized;

            // If target behind but too far, turn around
            if (componentForward > 0 && distanceToTarget > maxDistanceToReverse)
            {
                //Debug.Log("Target behind but too far");
                this.input.x = Mathf.Sign(componentRight) * (-1f);
                this.input.y = (-1f);
            }
            //Debug.Log("input = " + this.input);
            onInput?.Invoke(this.input);
        }
    }

    void SelectWaypoint(Transform waypoint)
    {
        this.nextWaypoint = waypoint;
        // Totally optional :
        // This "jitter" add a little randomness around the waypoint to make the AI slightly more human 
        this.nextWaypointPosition = this.nextWaypoint.position + new Vector3(Random.Range(-this.randomJitterOnPosition, this.randomJitterOnPosition), 0, Random.Range(-this.randomJitterOnPosition, this.randomJitterOnPosition));
    }
}