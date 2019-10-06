using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerAttack : MonoBehaviour
{
    private float timeBetweenAttack;
    public float startTimeBetweenAttack;

    public RectTransform attackPos;
    public LayerMask whatIsEnemy;

    private float targetDistance;
    public float aggroDistance;

    public float attackRange;
    public int damage;
    public int loadout;
    private string loadoutType = " ";

    private Transform enemy;
    private Vector3 targetPos;

    public GameObject projectile;
    private GameObject projectile0;

    // Start is called before the first frame update
    void Start()
    {
        CheckLoadout();
    }

    // Update is called once per frame
    void Update()
    {
        enemy = GetNearestTarget().transform;
        targetPos = enemy.position;
        targetDistance = Vector3.Distance(targetPos, transform.position);
        Debug.Log("Distance: " + targetDistance);
        if (timeBetweenAttack <= 0)
        {

            //attack

            if (targetDistance <= aggroDistance) //change this to "if in range && has target" or something
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
