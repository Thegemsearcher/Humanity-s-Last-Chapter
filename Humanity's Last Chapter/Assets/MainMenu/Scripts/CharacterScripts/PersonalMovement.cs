using Pathfinding;
using System.Collections.Generic;
using UnityEngine;
using static Node;

public class PersonalMovement : MonoBehaviour
{
    public RootNode BT;
    //public bool muzzleFlash = false;
    bool debugger = true;
    public bool moving = true;
    public float charactersMovespeed = 100f;
    public Vector3 relativePos = Vector3.zero;
    public Vector3 relativePosNonRotated = Vector3.zero;
    public Vector3 posPlusRel;
    public List<Vector3> waypoints = new List<Vector3>();
    Vector3 waypoint;
    RaycastHit2D positionBy;
    public LayerMask buildingLayer;
    private int currentWaypoint = 0;
   // public Vector2 direction = Vector2.zero;
    public GameObject manager;
    public bool ByFormation = true;
    public Vector3 posNotFormation = Vector3.zero;
    bool movingToRngPos = false;
    Vector3 rngPos = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        BT = GetComponent<BehaviourTree>().GetPcBt();
        manager = GameObject.FindGameObjectWithTag("CharacterManager");
        waypoint = transform.position;
        if (GetComponent<CharacterScript>().role != null && GetComponent<CharacterScript>().role.roleName.Equals("Commander"))
            manager.GetComponent<CharacterMovement>().hasCommander = true;
    }

    // Update is called once per frame
    void Update()
    {
        //GetComponentInChildren<Animator>().SetBool("flashAAA", false);
       
        if (debugger && positionBy)
            Debug.DrawLine(manager.transform.position, positionBy.point);
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

    public NodeStates RngPos()
    {
        if (moving)
            return NodeStates.fail;
        if (movingToRngPos)
        {
            GetComponent<AIDestinationSetter>().SetPosTarget(rngPos);
        } else
        {
            float newX = Random.Range(-1, 1);
            float newY = Random.Range(-1, 1);
            rngPos = new Vector3(transform.position.x + newX, transform.position.y + newY);
            movingToRngPos = true;
        }
        if (Vector2.Distance(rngPos, transform.position) < 0.5f)
        {
            movingToRngPos = false;
        }
        return NodeStates.success;
    }
    public NodeStates HasCommander()
    {
        //return NodeStates.success;
        if (manager.GetComponent<CharacterMovement>().hasCommander)
        {
            return NodeStates.success;
        }
        GetComponent<AIPath>().maxSpeed = 2;
        return NodeStates.fail;
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
        if (movingToRngPos)
            return;
        moving = true;
        positionBy = Physics2D.Raycast(posNotFormation, relativePos, relativePos.magnitude, buildingLayer);
        if (!ByFormation)
        {
            waypoint = posNotFormation + relativePos;
            if (positionBy != false)
            {
                Vector2 v = positionBy.point - (Vector2)transform.position;
                v.Normalize();
                v *= 0.1f;
                waypoint = positionBy.point + v;
                GetComponent<AIDestinationSetter>().SetPosTarget(waypoint);
            } else
            {
                GetComponent<AIDestinationSetter>().SetPosTarget(waypoint);
            }
            //GetComponent<AIDestinationSetter>().SetPosTarget(posNotFormation);
            return;
        }
        waypoint = manager.transform.position + relativePos;

        positionBy = Physics2D.Raycast(manager.transform.position, relativePos, relativePos.magnitude, buildingLayer);
        if (positionBy != false)
        {
            Vector2 v = positionBy.point - (Vector2)transform.position;
            v.Normalize();
            v *= 0.1f;
            waypoint = positionBy.point + v;
            GetComponent<AIDestinationSetter>().SetPosTarget(waypoint);
        } else
        {
            GetComponent<AIDestinationSetter>().SetPosTarget(waypoint);
        }
        

        if (Vector2.Distance(waypoint, transform.position) < 0.5f)
        {
            moving = false;
        }
    }
}
