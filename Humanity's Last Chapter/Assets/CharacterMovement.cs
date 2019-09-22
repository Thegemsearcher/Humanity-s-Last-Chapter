using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Vector3 mousePosition;
    public float moveSpeed = 0.1f;

    private List<Vector3> waypoints = new List<Vector3>();
    private int currentWaypoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            waypoints.Add(mousePosition);
        }
        if (waypoints.Count != 0)
        {
            transform.position = Vector2.Lerp(transform.position, waypoints[currentWaypoint], moveSpeed);
            //Debug.Log("distance  :   " + Vector3.Distance(transform.position, waypoints[currentWaypoint]));
            if (Vector3.Distance(transform.position, waypoints[currentWaypoint]) < 20 && waypoints.Count > currentWaypoint + 1)
            {
                //Debug.Log("in if");
                currentWaypoint++;
            }
        }
    }
}