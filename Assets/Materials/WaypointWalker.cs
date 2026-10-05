using UnityEngine;
using UnityEngine.AI; // Required for NavMesh

public class WaypointWalker : MonoBehaviour
{
    [Header("Settings")]
    public Transform[] waypoints; // Array to store the empty objects
    public float minDistance = 0.5f; // Distance to consider the point reached

    private NavMeshAgent agent;
    private Animator animator;
    private int currentIndex = 0;

    void Start()
    {
        // Get components on this object
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        // If there are waypoints, go to the first one
        if (waypoints.Length > 0)
        {
            agent.destination = waypoints[currentIndex].position;
        }
    }

    void Update()
    {
        // If there are no waypoints, do nothing
        if (waypoints.Length == 0) return;

        // Update animation (optional, see Part 5)
        if (animator != null)
        {
            // If agent speed is greater than 0.1, it is walking
            animator.SetBool("isWalking", agent.velocity.magnitude > 0.1f);
        }

        // Check if the agent is still calculating the path
        if (!agent.pathPending)
        {
            // If remaining distance is less than minDistance, it reached the point
            if (agent.remainingDistance <= minDistance)
            {
                // Go to the next waypoint
                currentIndex++;

                // If it reached the last one, loop back to the first
                if (currentIndex >= waypoints.Length)
                {
                    currentIndex = 0;
                }

                // Set the new destination
                agent.destination = waypoints[currentIndex].position;
            }
        }
    }
}