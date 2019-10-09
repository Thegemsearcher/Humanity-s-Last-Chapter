using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Node;

public class Enemy : MonoBehaviour
{
    public int health;
    public float speed = 1.5f;
    private Vector3 target;
    public string id;

    GameObject[] pcs;
    public float aggroRange = 1.5f;
    public float atkRange = 0.5f;
    public int dmg = 1;
    public LayerMask pcLayer;

    public ParticleSystem bloodEffect;

    // Start is called before the first frame update
    void Start()
    {
        target = transform.position;
        pcs = GameObject.FindGameObjectsWithTag("Character");
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }

        MovementForTest();
    }

    public void TakeDamage(int damage)
    {
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
        health -= damage;
    }

    public NodeStates InAggroRange()
    {
        foreach (GameObject pc in pcs)
        {
            if (Vector3.Distance(transform.position, pc.transform.position) < aggroRange)
            {
                return NodeStates.success;
            }
        }
        
        return NodeStates.fail;
    }

    public NodeStates MoveTowardsClosestPc()
    {
        GameObject closestPc = pcs[0];
        foreach (GameObject pc in pcs)
        {
            if (Vector3.Distance(transform.position, pc.transform.position) < Vector3.Distance(transform.position, closestPc.transform.position))
            {
                closestPc = pc;
            }
        }
        GetComponent<AIDestinationSetter>().SetPosTarget(closestPc.transform.position);
        return NodeStates.success;
    }

    public NodeStates InMeleeRange()
    {
        Collider2D[] pcsToDamage = Physics2D.OverlapCircleAll(transform.position, atkRange, pcLayer);

        for (int i = 0; i < pcsToDamage.Length; i++)
        {
            pcsToDamage[i].GetComponent<stats>().hp -= dmg;
        }

        return NodeStates.success;
    }
    void MovementForTest()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    target.z = transform.position.z;
        //}
        //transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}
