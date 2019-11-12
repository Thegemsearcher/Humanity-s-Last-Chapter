using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    Vector3 setPosTo = new Vector3(0, 0, 0);
    GameObject[] toGoTo;
    public Vector3[] waypoints;
    int currentWP;
    float offset = 3f;
    RootNode BT;
    // Start is called before the first frame update
    void Start()
    {
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
            for (int i = 0; i < waypoints.Length; i++)
            {
                if (go.GetComponent<BoxCollider2D>().OverlapPoint(waypoints[i]))
                {
                    waypoints[i] = transform.position;
                }
            }
        }



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
