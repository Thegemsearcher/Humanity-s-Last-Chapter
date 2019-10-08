using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using static Node;

public class PlayerAttack : MonoBehaviour
{
    public float speed = 1.5f;
    private Vector3 destination;
    private bool walking;

    private float attackTimer;
    public float timeBetweenAttack;

    public RectTransform attackPos;
    public LayerMask whatIsEnemy;
    public LayerMask humansAndBuildings;
    RaycastHit2D hitInfo;

    public float attackRange;
    public int damage;
    public int loadout;
    private string loadoutType = " ";

    private Transform enemy;
    private Vector3 enemyPos;
    private float enemyDistance;
    public float aggroDistance;

    public GameObject projectile;
    private GameObject projectile0;

    void Start()
    {
        //destination = transform.position;

        CheckLoadout();
    }

    void Update()
    {
        //For testing only
        //TestMoveToDestination();
        //TestCombat();

        if (attackTimer > 0)
            attackTimer -= Time.deltaTime;
    }

    public NodeStates LineOfSight()
    {
        hitInfo = Physics2D.Raycast(transform.position, enemyPos, aggroDistance, humansAndBuildings);
        if (hitInfo.collider != null)
        {
            return NodeStates.fail;
        }

        return NodeStates.success;
    }

    public NodeStates IsRanged()
    {
        if (loadoutType == "Pistol")
            return NodeStates.success;
        else
            return NodeStates.fail;
    }

    public NodeStates InCombatRange()
    {
        GameObject go = GetNearestTarget();
        if (go.Equals(gameObject))
        {
            return NodeStates.fail;
        }

        enemy = go.transform;
        enemyPos = enemy.position;
        enemyDistance = Vector3.Distance(enemyPos, transform.position);
        if (attackTimer <= 0)
        {
            if (enemyDistance <= aggroDistance)
            {
                return NodeStates.success;
            }
        }
        return NodeStates.fail;
    }

    public NodeStates RangeAttack()
    {
        projectile0 = Instantiate(projectile, transform.position, Quaternion.identity);
        attackTimer = timeBetweenAttack;
        return NodeStates.success;
    }

    public NodeStates MeleeAttack()
    {
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(transform.position, attackRange, whatIsEnemy);

        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
        }
        return NodeStates.success;
    }

    private void TestCombat()
    {
        enemy = GetNearestTarget().transform;
        enemyPos = enemy.position;
        enemyDistance = Vector3.Distance(enemyPos, transform.position);
        Debug.Log("Distance: " + enemyDistance);
        if (attackTimer <= 0)
        {
            if (enemyDistance <= aggroDistance)
            {
                if (loadoutType == "Melee")
                {
                    Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(transform.position, attackRange, whatIsEnemy);

                    for (int i = 0; i < enemiesToDamage.Length; i++)
                    {
                        enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                    }
                }
                if (loadoutType == "Pistol")
                {
                    //projectile0.GetComponent<Projectile>().spread = 0f;
                    projectile0 = Instantiate(projectile, transform.position, Quaternion.identity);
                }
                if (loadoutType == "Shotgun")
                {
                    //projectile0.GetComponent<Projectile>().spread = 1f;
                    projectile0 = Instantiate(projectile, transform.position, Quaternion.identity);
                    projectile0 = Instantiate(projectile, transform.position, Quaternion.identity);
                    projectile0 = Instantiate(projectile, transform.position, Quaternion.identity);
                    projectile0 = Instantiate(projectile, transform.position, Quaternion.identity);
                }
                attackTimer = timeBetweenAttack;
            }
        }
    }

    private void TestMoveToDestination()
    {
        if (Input.GetMouseButtonDown(1))
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            destination.z = transform.position.z;
        }
        transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
    }

    GameObject GetNearestTarget()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            return gameObject;
        }

        return GameObject.FindGameObjectsWithTag("Enemy").Aggregate((o1, o2) => Vector3.Distance(o1.transform.position, this.transform.position) 
        > Vector3.Distance(o2.transform.position, this.transform.position) ? o2 : o1);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    void CheckLoadout()
    {
        if (loadout == 0)
        {
            loadoutType = "Melee";
        }
        else if (loadout == 1)
        {
            loadoutType = "Pistol";
        }
        else if (loadout == 2)
        {
            loadoutType = "Shotgun";
        }
    }
}
