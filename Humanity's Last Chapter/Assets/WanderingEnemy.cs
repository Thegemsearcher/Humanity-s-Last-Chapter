using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;
using static Node;

public class WanderingEnemy : MonoBehaviour
{
    //IAstarAI enemyAstar;

    GameObject[] toGoTo;
    public Vector3[] waypoints;
    int currentWP;
    float offset = 3f;
    RootNode BT;
    // Start is called before the first frame update
    void Start()
    {
        //toGoTo = GameObject.FindGameObjectsWithTag("Enemy");
        //waypoints = new Vector3[toGoTo.Length];
        //for (int i = 0;i < toGoTo.Length; i++)
        //{
        //    waypoints[i] = toGoTo[i].transform.position;
        //}

        GameObject[] walls = GameObject.FindGameObjectsWithTag("Building");

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

        foreach (GameObject go in walls)
        {
            for (int i = 0; i < waypoints.Length;i++)
            {
                if (go.GetComponent<BoxCollider2D>().OverlapPoint(waypoints[i]))
                {
                    waypoints[i] = transform.position;
                }
            }
        }

        GetComponent<AIDestinationSetter>().SetPosTarget(waypoints[currentWP]);
        //enemyAstar = GetComponent<IAstarAI>();
        currentWP = 0;
        //enemyAstar.destination = waypoints[currentWP];
        //Debug.Log("" + waypoints.Length);
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
       
        if (currentWP < waypoints.Length)
        {
            if (Vector2.Distance(waypoints[currentWP], transform.position) < 1.3f)
            {
                return NodeStates.success;
            }
        }
        //else
        //{
        //    currentWP = 0;
        //}
        return NodeStates.fail;
    }

    public NodeStates NextWaypoint()
    {
        currentWP++;
        if (currentWP < waypoints.Length)
        {
            GetComponent<AIDestinationSetter>().SetPosTarget(waypoints[currentWP]);
        }
        else
        {
            currentWP = 0;
        }
        //Debug.Log("" + currentWP);
        return NodeStates.success;
    }
}
