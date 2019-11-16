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

    public GameObject[] pcs;
    public float aggroRange = 4f;
    public float atkRange = 0.75f;
    public int dmg = 1;
    public LayerMask pcLayer;
    
    public float attackTimer;
    public float timeBetweenAttack;

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
        if (attackTimer > 0)
            attackTimer -= Time.deltaTime;
        RemovePcFromList();
    }

    public void RemovePcFromList()
    {
       pcs = GameObject.FindGameObjectsWithTag("Character");
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
    }

    public NodeStates InAggroRange()
    {
        
        foreach (GameObject pc in pcs)
        {
            //Debug.Log(""+ Vector3.Distance(transform.position, pc.transform.position));
            if (Vector3.Distance(transform.position, pc.transform.position) < aggroRange)
            {
                //Debug.Log("pcn är inom aggrorangen");
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
                if (pc.gameObject.activeInHierarchy)
                {
                    closestPc = pc;
                }
            }
        }
        GetComponent<AIDestinationSetter>().SetPosTarget(closestPc.transform.position);
        return NodeStates.success;
    }

    public NodeStates InMeleeRange()
    {
        if (attackTimer > 0)
        {
            return NodeStates.fail;
        }
        attackTimer = timeBetweenAttack;
        Collider2D[] pcsToDamage = Physics2D.OverlapCircleAll(transform.position, atkRange, pcLayer);
        bool hitPc = false;
        for (int i = 0; i < pcsToDamage.Length; i++)
        {
            hitPc = true;
            pcsToDamage[i].GetComponent<Stats>().TakeDamage(dmg);
        }
        if (hitPc)
            return NodeStates.success;
        return NodeStates.fail;
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
