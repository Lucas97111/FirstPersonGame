using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform target;

    public float trackingdistance = 10f;

    public Transform[] waypoints;
    public int index;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(waypoints[index].position);
    }

    // Update is called once per frame
    void Update()
    {

        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            index++;

            if (index >= waypoints.Length)
            {
                index = 0;
            }

            agent.SetDestination(waypoints[index].position);


        }

        else if (Vector3.Distance(transform.position, target.position) < trackingdistance)
        {
            print("player in range");
            agent.SetDestination(target.position);

        }

    }
}
