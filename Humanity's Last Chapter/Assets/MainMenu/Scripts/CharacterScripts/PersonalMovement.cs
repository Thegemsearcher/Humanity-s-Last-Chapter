using System.Collections.Generic;
using UnityEngine;

public class PersonalMovement : MonoBehaviour
{
    public float charactersMovespeed = 0.035f;
    public Vector3 relativePos = Vector3.zero;
    public Vector3 posPlusRel;
    private List<Vector3> waypoints = new List<Vector3>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        posPlusRel = transform.parent.position + relativePos;
        Positioning();
        Movement();
    }

    public void AddWaypoint(Vector3 pos)
    {
        waypoints.Add(pos);
    }

    private void Positioning()
    {
        if ((transform.parent.position + relativePos) != transform.parent.position &&
            Vector3.Distance(transform.position, transform.parent.position + relativePos) > 10)
        {
            waypoints.Add(posPlusRel);
            //Debug.Log(" " + (gameObject.transform.parent.position + relativePos));
            //Debug.Log("distance  :   " + Vector3.Distance(transform.position, gameObject.transform.parent.position + relativePos));
            //Debug.Log("relative pos  :  " + relativePos);
        }
    }

    private void Movement()
    {
        //transform.position = transform.parent.position + relativePos;
        bool toRemove = false;
        if (waypoints.Count != 0)
        {

            Debug.Log("in if 1 ");
            transform.position = Vector2.Lerp(transform.position, waypoints[0], charactersMovespeed);

            if (Vector3.Distance(transform.position, waypoints[0]) < 20 /*&& waypoints.Count > 1*/)
            {
                Debug.Log("in if 2 ");
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
