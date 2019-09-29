using System.Collections.Generic;
using UnityEngine;

public class PersonalMovement : MonoBehaviour
{
    public float charactersMovespeed = 0.035f;
    public Vector3 relativePos = Vector3.zero;
    public Vector3 posPlusRel;
    public Vector3 posi;
    private List<Vector3> waypoints = new List<Vector3>();
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        posi = transform.position;
        Positioning();
        Movement();
    }

    public void AddWaypoint(Vector3 pos)
    {
        waypoints.Add(pos);
    }

    public void AddRelativeWaypoint(Vector3 toAdd)
    {
        Debug.Log("adding: " + toAdd);
        posPlusRel = toAdd + relativePos;
        waypoints.Add(posPlusRel);
    }

    public void FlushWaypoints()
    {
        waypoints.Clear();
    }

    private void Positioning()
    {
        //if ((transform.parent.position + relativePos) != transform.parent.position 
        //    /*&& Vector3.Distance(transform.position, posPlusRel) > 10*/)
        //{
        //    waypoints.Add(posPlusRel);
        //    //Debug.Log(" " + (gameObject.transform.parent.position + relativePos));
        //    //Debug.Log("distance  :   " + Vector3.Distance(transform.position, gameObject.transform.parent.position + relativePos));
        //    //Debug.Log("relative pos  :  " + relativePos);
        //}
    }

    private void Movement()
    {
        //transform.position = transform.parent.position + relativePos;
        bool toRemove = false;
        Debug.Log("" + waypoints.Count);
        if (waypoints.Count > 0)
        {

            Debug.Log("in1");
            transform.position = Vector2.Lerp(transform.position, waypoints[0], charactersMovespeed);
            //Debug.Log("" + posi.x + ", " + posi.y + " and waypoint at: " + +waypoints[0].x + ", " + waypoints[0]);
            if (Vector3.Distance(transform.position, waypoints[0]) < 11 /*&& waypoints.Count > 1*/)
            {
                Debug.Log("in2");
                toRemove = true;
                //currentWaypoint++;
            }
        }
        if (toRemove)
        {
            Debug.Log("removed when pos at: " + posi.x + ", " + posi.y + " and waypoint at: " + + waypoints[0].x + ", " + waypoints[0]);
            waypoints.Remove(waypoints[0]);
            toRemove = false;
        }
    }
}
