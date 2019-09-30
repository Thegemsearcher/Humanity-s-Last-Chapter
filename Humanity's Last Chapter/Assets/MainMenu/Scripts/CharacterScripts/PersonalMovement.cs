using System.Collections.Generic;
using UnityEngine;

public class PersonalMovement : MonoBehaviour
{
    public float charactersMovespeed = 100f;
    public Vector3 relativePos = Vector3.zero;
    public Vector3 posPlusRel;
    public Vector3 posi;
    public List<Vector3> waypoints = new List<Vector3>();
    private int currentWaypoint = 0;
    public Vector2 direction = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        charactersMovespeed = 100f;
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
    }

    private void Movement()
    {
        //tog bort 'lerp- movementen' och la till vanligare movement istället
        if (waypoints.Count != 0)
        {
            direction = waypoints[currentWaypoint] - transform.position;
            
            //Debug.Log("distance  :   " + Vector3.Distance(transform.position, waypoints[currentWaypoint]));
            if (direction.magnitude < 10)
            {
                currentWaypoint++;
               
            }

            direction = direction.normalized;
            transform.position += new Vector3(direction.x * charactersMovespeed * Time.deltaTime, direction.y * charactersMovespeed * Time.deltaTime, 0);

            if (currentWaypoint >= waypoints.Count)
            {
                currentWaypoint = 0;
                waypoints.Clear();
            }
        }
    }
}
