using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonalMovement : MonoBehaviour
{
    public float charactersMovespeed = 1f;
    public Vector3 relativePos = Vector3.zero;
    private List<Vector3> waypoints = new List<Vector3>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Positioning();
        //Movement();
    }

    public void AddWaypoint(Vector3 pos)
    {
        waypoints.Add(pos);
    }

    private void Positioning()
    {
        if (true)
        {
            AddWaypoint(transform.parent.position + relativePos);
            //Debug.Log(" " + (gameObject.transform.parent.position + relativePos));
            //Debug.Log("distance  :   " + Vector3.Distance(transform.position, gameObject.transform.parent.position + relativePos));
            //Debug.Log("relative pos  :  " + relativePos);
        }
    }

    private void Movement()
    {
        bool toRemove = false;
        if (waypoints.Count != 0)
        {
            transform.position = Vector2.Lerp(transform.position, waypoints[0], charactersMovespeed);
            
            if (Vector3.Distance(transform.position, waypoints[0]) < 20 && waypoints.Count > 1)
            {
                Debug.Log("in if");
                toRemove = true;
                //currentWaypoint++;
            }
        }
        if (toRemove)
        {
            waypoints.Remove(waypoints[0]);
            toRemove = false;
        }
    }
}
