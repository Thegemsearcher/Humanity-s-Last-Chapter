using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class WanderingEnemy : MonoBehaviour
{
    IAstarAI enemyAI;
    GameObject[] waypoints;
    int currentWP;
    // Start is called before the first frame update
    void Start()
    {
        waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        enemyAI = GetComponent<IAstarAI>();
        currentWP = 0;
        enemyAI.destination = waypoints[currentWP].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (waypoints.Length == 0)
        {
            return;
        }
        if (Vector2.Distance(waypoints[currentWP].transform.position, enemyAI.position ) < 3.0f)
        {
            currentWP++;
            enemyAI.destination = waypoints[currentWP].transform.position;
            if (currentWP >= waypoints.Length)
            {
                currentWP = 0;
            }
        }
    }
}
