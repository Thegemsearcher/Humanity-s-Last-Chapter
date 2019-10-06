using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Vector3 mousePosition;
    public float moveSpeed = 1000f;

    Vector3 direction = Vector3.zero;
    public List<GameObject> pcs = new List<GameObject>();
    public List<Vector3> waypoints = new List<Vector3>();
    private int currentWaypoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        waypoints.Add(new Vector3(1, 0, 0));   
    }

    // Update is called once per frame
    void Update()
    {
        InputMovement();
        Movement();
    }
    public void AddPc(GameObject toAdd)
    {
        pcs.Add(toAdd);
    }
    private void InputMovement()
    {
        if (Input.GetMouseButtonDown(1) && Input.GetKey(KeyCode.LeftShift))
        {
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            waypoints.Add(mousePosition);
            //foreach (GameObject child in pcs)
            //{
            //    //Debug.Log("will add: " + mousePosition);
            //    child.GetComponentInChildren<PersonalMovement>().AddRelativeWaypoint(mousePosition);
            //}
        }
        if (Input.GetMouseButton(1) && !Input.GetKey(KeyCode.LeftShift))
        {
            waypoints.Clear();
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            waypoints.Add(mousePosition);

            //foreach (GameObject child in pcs)
            //{
            //    child.GetComponentInChildren<PersonalMovement>().FlushWaypoints();
            //    child.GetComponentInChildren<PersonalMovement>().AddRelativeWaypoint(mousePosition);
            //}
        }
    }

    private void Movement()
    {
        if (waypoints.Count != 0)
        {
            direction = waypoints[currentWaypoint] - transform.position;
            GetComponent<AIDestinationSetter>().SetPosTarget(waypoints[currentWaypoint]);
            //transform.position = Vector2.Lerp(transform.position, waypoints[currentWaypoint], moveSpeed);
            //Debug.Log("distance  :   " + Vector3.Distance(transform.position, waypoints[currentWaypoint]));
            if (direction.magnitude < 2)
            {
                currentWaypoint++;
            }
            //direction = direction.normalized;
            //transform.position += direction * moveSpeed * Time.deltaTime;
            if (currentWaypoint >= waypoints.Count)
            {
                //Debug.Log("in");
                currentWaypoint = 0;
                waypoints.Clear();
            }
        }
    }
}