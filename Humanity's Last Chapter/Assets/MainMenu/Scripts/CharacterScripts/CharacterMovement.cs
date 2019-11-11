using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Vector3 mousePosition;
    public float moveSpeed = 1000f;

    Vector3 direction = Vector3.zero;
    RaycastHit2D ray;

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
    /// <summary>
    /// obs fungerar ej just nu
    /// </summary>
    /// <param name="rotateTowards"></param>
    public void RotateFormation(Vector3 rotateTowards)
    {
        //Vector3 to = new Vector3(rotateTowards.x, rotateTowards.y, 0);
        //Vector3 from = new Vector3(transform.position.x, transform.position.y, 0);
        //float angle = Vector3.Angle(from, to);
        //foreach (GameObject pc in pcs)
        //{
        //    Debug.Log("gnasl");
        //    Vector3 toSet = pc.GetComponent<PersonalMovement>().relativePos;
        //    toSet = Quaternion.Euler(new Vector3(0,0,angle)) * toSet;
        //    pc.GetComponent<PersonalMovement>().relativePos = toSet;
        //}
    }

    private void InputMovement()
    {
        if (Input.GetMouseButtonDown(1) && Input.GetKey(KeyCode.LeftShift))
        {
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            waypoints.Add(mousePosition);
            
            
            RotateFormation(mousePosition);
        }
        if (Input.GetMouseButton(1) && !Input.GetKey(KeyCode.LeftShift))
        {
            waypoints.Clear();
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            waypoints.Add(mousePosition);

            //ray = Physics2D.Raycast(transform.position,mousePosition, Vector2.Distance(transform.position, mousePosition));
            
            //if (!ray)
            //{
            //    Debug.DrawLine(transform.position, ray.point);
            //    Vector3 v = transform.position;
            //    foreach (GameObject go in pcs)
            //    {
            //        if (Vector2.Distance(go.transform.position, mousePosition) < Vector2.Distance(v, mousePosition))
            //        {
            //            v = go.transform.position;
            //        }
            //    }
            //    transform.position = v;
            //}

            RotateFormation(mousePosition);
        }
    }

    private void Movement()
    {
        if (waypoints.Count != 0)
        {
            direction = waypoints[currentWaypoint] - transform.position;
            GetComponent<AIDestinationSetter>().SetPosTarget(waypoints[currentWaypoint]);
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