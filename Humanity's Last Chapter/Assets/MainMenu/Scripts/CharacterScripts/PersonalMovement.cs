using Pathfinding;
using System.Collections.Generic;
using UnityEngine;

public class PersonalMovement : MonoBehaviour
{
    public RootNode BT;

    public float charactersMovespeed = 100f;
    public Vector3 relativePos = Vector3.zero;
    public Vector3 posPlusRel;
    public List<Vector3> waypoints = new List<Vector3>();
    Vector3 waypoint;

    private int currentWaypoint = 0;
    public Vector2 direction = Vector2.zero;
    private GameObject manager;
    // Start is called before the first frame update
    void Start()
    {
        BT = GetComponent<BehaviourTree>().GetPcBt();
        manager = GameObject.FindGameObjectWithTag("CharacterManager");
        waypoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        BT.Start();
        Movement();
    }

    public void AddWaypoint(Vector3 pos)
    {
        waypoints.Add(new Vector3(pos.x, pos.y, 0));
    }

    public void AddRelativeWaypoint(Vector3 toAdd)
    {
        //Debug.Log("adding: " + toAdd);
        posPlusRel = toAdd + relativePos;
        waypoints.Add(posPlusRel);
    }

    public void FlushWaypoints()
    {
        waypoints.Clear();
    }

    private void Positioning()
    {
        waypoints.Add(manager.transform.position + relativePos);
    }

    private void Movement()
    {
        waypoint = manager.transform.position + relativePos;
        GetComponent<AIDestinationSetter>().SetPosTarget(waypoint);
        
        //tog bort 'lerp- movementen' och la till vanligare movement istället
        //if (waypoints.Count != 0)
        //{
        //    direction = waypoints[currentWaypoint] - transform.position;
        //    GetComponent<AIDestinationSetter>().SetPosTarget(waypoints[currentWaypoint]);
        //    //Debug.Log("distance  :   " + Vector3.Distance(transform.position, waypoints[currentWaypoint]));
        //    if (direction.magnitude < 2)
        //    {
        //        Positioning();
        //        currentWaypoint++;
        //    }

        //    direction = direction.normalized;
        //    //transform.position += new Vector3(direction.x * charactersMovespeed * Time.deltaTime, direction.y * charactersMovespeed * Time.deltaTime, 0);

        //    if (currentWaypoint >= waypoints.Count)
        //    {
        //        currentWaypoint = 0;
        //        waypoints.Clear();
        //    }
        //}
    }
}
