using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerAttack : MonoBehaviour
{
    public float speed = 1.5f;
    private Vector3 destination;
    private bool walking;

    private float timeBetweenAttack;
    public float startTimeBetweenAttack;

    public RectTransform attackPos;
    public LayerMask whatIsEnemy;

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

    // Start is called before the first frame update
    void Start()
    {
        destination = transform.position;

        CheckLoadout();
    }

    // Update is called once per frame
    void Update()
    {
        MoveToDestination();

        enemy = GetNearestTarget().transform;
        enemyPos = enemy.position;
        enemyDistance = Vector3.Distance(enemyPos, transform.position);
        Debug.Log("Distance: " + enemyDistance);
        if (timeBetweenAttack <= 0)
        {
            if (enemyDistance <= aggroDistance) //change this to "if in range && has target" or something
            {
                if (loadoutType == "Melee")
                {
                    Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(transform.position, attackRange, whatIsEnemy);

                    for (int i = 0; i < enemiesToDamage.Length; i++)
                    {
                        enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                    }
                }
                if (loadoutType == "Ranged")
                {
                    projectile0 = Instantiate(projectile, transform.position, Quaternion.identity);

                    //projectile0.transform.parent = gameObject.transform;
                    //projectile0.transform.localScale = new Vector3(1, 1, 1);
                }
                timeBetweenAttack = startTimeBetweenAttack;
            }
        }
        else
        {
            timeBetweenAttack -= Time.deltaTime;
        }
    }

    void MoveToDestination()
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
        return GameObject.FindGameObjectsWithTag("Enemy").Aggregate((o1, o2) => Vector3.Distance(o1.transform.position, this.transform.position) > Vector3.Distance(o2.transform.position, this.transform.position) ? o2 : o1);
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
            loadoutType = "Ranged";
        }
    }
}
