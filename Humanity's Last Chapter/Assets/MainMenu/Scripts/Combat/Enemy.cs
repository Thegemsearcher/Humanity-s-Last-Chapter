using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Node;

public class Enemy : MonoBehaviour {
    public int health;
    public float speed = 1.5f;
    private Vector3 target;
    public string id;

    public int inventorySize;
    private string[] inventory;

    public GameObject[] pcs;
    public float aggroRange = 4f;
    public float atkRange = 0.75f;
    public int dmg = 1;
    public LayerMask pcLayer;

    public float attackTimer;
    public float timeBetweenAttack;

    public Animator animator;

    public ParticleSystem bloodEffect;
    public bool hasSeenEnemy = false;

    public GameObject EnemyCorpse;

    public bool ranged;
    // Start is called before the first frame update
    void Start() {
        target = transform.position;
        pcs = GameObject.FindGameObjectsWithTag("Character");
        inventory = new string[inventorySize];
    }

    // Update is called once per frame
    void Update() {
        if (health <= 0) {
            GameObject corpse = Instantiate(EnemyCorpse);
            corpse.transform.position = transform.position;
            corpse.transform.rotation = transform.rotation * Quaternion.Euler(0, 0, 180);
            if (!ranged)
                GetInventory();
            Destroy(gameObject);
        }
        if (attackTimer > 0)
            attackTimer -= Time.deltaTime;
        RemovePcFromList();
    }

    private void GetInventory() {
        for (int i = 0; i < inventory.Length; i++) {
            inventory[i] = "hi0";
        }
        GetComponent<InventoryScript>().GetInventory(inventory, gameObject.name);
    }

    public void RemovePcFromList() {
        pcs = GameObject.FindGameObjectsWithTag("Character");
    }

    public void TakeDamage(int damage) {
        health -= damage;
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
    }

    public NodeStates InAggroRange() {
        foreach (GameObject pc in pcs) {
            //Debug.Log(""+ Vector3.Distance(transform.position, pc.transform.position));
            if (Vector3.Distance(transform.position, pc.transform.position) < aggroRange) {
                //closestPC = Vector3.Distance(transform.position, pc.transform.position);
                //Debug.Log("pcn är inom aggrorangen");
                //iCombatTree = true;
                hasSeenEnemy = true;
                return NodeStates.success;
            }
        }
        //iCombatTree = false;
        return NodeStates.fail;
    }

    public NodeStates MoveTowardsClosestPc() {
        GameObject closestPc = pcs[0];
        foreach (GameObject pc in pcs) {
            if (Vector3.Distance(transform.position, pc.transform.position) < Vector3.Distance(transform.position, closestPc.transform.position)) {
                if (pc.gameObject.activeInHierarchy) {
                    closestPc = pc;
                }
            }
        }
        GetComponent<AIDestinationSetter>().SetPosTarget(closestPc.transform.position);
        return NodeStates.success;
    }

    public NodeStates InMeleeRange() {
        if (attackTimer > 0) {
            return NodeStates.fail;
        }

        attackTimer = timeBetweenAttack;
        Collider2D[] pcsToDamage = Physics2D.OverlapCircleAll(transform.position, atkRange, pcLayer);
        bool hitPc = false;
        for (int i = 0; i < pcsToDamage.Length; i++) {
            animator.SetBool("Attacking", true);
            hitPc = true;
            pcsToDamage[i].GetComponent<Stats>().TakeDamage(dmg);
        }
        if (hitPc)
            return NodeStates.success;

        animator.SetBool("Attacking", false);
        return NodeStates.fail;
    }
    void MovementForTest() {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    target.z = transform.position.z;
        //}
        //transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}
