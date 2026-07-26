using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovement : MonoBehaviour
{
    [Header("Path")]
    public Transform pathParent;

    [Header("Movement")]
    public float waypointDelay = 0f;

    private NavMeshAgent agent;
    private Transform[] waypoints;
    private int currentWaypoint = 0;
    private float waypointTimer = 0f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        //for krugs if we do that
        waypoints = new Transform[pathParent.childCount];

        for (int i = 0; i < pathParent.childCount; i++)
        {
            waypoints[i] = pathParent.GetChild(i);
        }

        if (waypoints.Length > 0)
        {
            agent.SetDestination(waypoints[currentWaypoint].position);
            currentWaypoint++;
        }
    }

    void Update()
    {
        if (waypoints.Length == 0)
            return;

        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            waypointTimer += Time.deltaTime;

            if (waypointTimer >= waypointDelay)
            {
                waypointTimer = 0f;
                GoToNextWaypoint();
            }
        }
    }

    void GoToNextWaypoint()
    {
        if (currentWaypoint >= waypoints.Length)
        {
            ReachGoal();
            return;
        }

        agent.SetDestination(waypoints[currentWaypoint].position);
        currentWaypoint++;
    }

    void ReachGoal()
    {
        // Ian put the damage received in here

        Destroy(gameObject);
    }
}