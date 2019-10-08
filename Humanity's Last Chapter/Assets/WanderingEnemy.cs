using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;
using static Node;

public class WanderingEnemy : MonoBehaviour
{
    IAstarAI enemyAstar;
    Vector3[] waypoints;
    int currentWP;
    float offset = 1.5f;
    RootNode BT;
    // Start is called before the first frame update
    void Start()
    {
        waypoints = new Vector3[3];
        //waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        Vector3 toAdd = new Vector3(Random.Range(transform.position.x - offset, transform.position.x + offset), 
            Random.Range(transform.position.y - offset, transform.position.y + offset), 0);
        waypoints[0] = toAdd;
        toAdd = new Vector3(Random.Range(transform.position.x - offset, transform.position.x + offset),
            Random.Range(transform.position.y - offset, transform.position.y + offset), 0);
        waypoints[1] = toAdd;
        toAdd = new Vector3(Random.Range(transform.position.x - offset, transform.position.x + offset),
            Random.Range(transform.position.y - offset, transform.position.y + offset), 0);
        waypoints[2] = toAdd;

        enemyAstar = GetComponent<IAstarAI>();
        currentWP = 0;
        //enemyAstar.destination = waypoints[currentWP];
        Debug.Log("" + waypoints.Length);
        BT = GetComponent<BehvaiourTree>().GetEnemyBt();
    }

    // Update is called once per frame
    void Update()
    {
        if(BT == null)
        {
            Debug.Log("inget BT");
            return;
        }

        BT.Start();
        //if (waypoints.Length == 0)
        //{
        //    return;
        //}
        //if (Vector2.Distance(waypoints[currentWP], enemyAstar.position ) < 3.0f)
        //{
        //    currentWP++;
        //    enemyAstar.destination = waypoints[currentWP];
        //    if (currentWP >= waypoints.Length)
        //    {
        //        currentWP = 0;
        //    }
        //}
    }

    public NodeStates CloseToWaypoint()
    {
        if (waypoints.Length == 0)
        {
            return NodeStates.fail;
        }
        //Debug.Log("" + currentWP);
        if (Vector2.Distance(waypoints[currentWP], enemyAstar.position) < 3.0f)
        {
            return NodeStates.success;
        }

        return NodeStates.fail;
    }

    public NodeStates NextWaypoint()
    {
        currentWP++;
        if (currentWP < waypoints.Length)
        {
            enemyAstar.destination = waypoints[currentWP];
        }
        if (currentWP > waypoints.Length)
        {
            currentWP = 0;
        }
        return NodeStates.success;
    }
}
