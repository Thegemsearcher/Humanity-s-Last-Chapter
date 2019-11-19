using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Node;

public class TurretScript : MonoBehaviour
{
    public float range;
    public int dmg;
    public float attackTimer;
    public int timeBetweenAttacks;
    GameObject projectile;
    public GameObject Projectile;
    public LayerMask whatIsEnemy;
    RaycastHit2D ray;
    GameObject[] enemies;
    GameObject closestEnemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InRangeAndSight();
    }
    public NodeStates InRangeAndSight()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float closest = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float testClosest = (Vector3.Distance(transform.position, enemy.transform.position));

            if (testClosest < closest)
            {
                closest = testClosest;
                closestEnemy = enemy;
            }
        }
        ray = Physics2D.Raycast(transform.position, closestEnemy.transform.position - transform.position);
        if (!ray)
            return NodeStates.fail;
        else if (ray.collider.tag.Equals("Enemy"))
        {
            Rotate();
            Debug.DrawLine(transform.position, ray.point);
            return NodeStates.success;
        }
            
        return NodeStates.fail;
    }


    public void Rotate()
    {
        float rotZ;
        Vector3 difference = closestEnemy.transform.position - transform.position;
        rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        gameObject.transform.GetChild(0).rotation = Quaternion.Euler(0f, 0f, rotZ);
    }

}
