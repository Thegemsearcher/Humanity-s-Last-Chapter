using Pathfinding;
using System.Collections.Generic;
using UnityEngine;

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
    private GameObject manager;
    public bool ByFormation = true;
    public Vector3 posNotFormation = Vector3.zero;

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
        //GetComponentInChildren<Animator>().SetBool("flashAAA", false);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ByFormation = true;
            GetComponent<SpriteRenderer>().color = Color.white;
        }
        if (debugger && positionBy)
            Debug.DrawLine(manager.transform.position, positionBy.point);
        BT.Start();
        Movement();

      
    }
    /*float width, height;
        if (startPos.x > endPos.x)
            width = startPos.x - endPos.x;
        else
            width = endPos.x - startPos.x;

        if (startPos.y > endPos.y)
            height = startPos.y - endPos.y;
        else
            height = endPos.y - startPos.y;
        Rect toSelect;

        if (endPos.x > startPos.x)
        {
            if (endPos.y > startPos.y)
                toSelect = new Rect(startPos.x, Screen.height - endPos.y, width, height);
            else
                toSelect = new Rect(startPos.x, Screen.height - startPos.y, width, height);
        } else
        {
            if (endPos.y > startPos.y)
                toSelect = new Rect(endPos.x, Screen.height - endPos.y, width, height);
            else
                toSelect = new Rect(endPos.x, Screen.height - startPos.y, width, height);
        }
     */
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
