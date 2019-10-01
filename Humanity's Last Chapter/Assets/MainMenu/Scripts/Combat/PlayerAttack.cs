using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBetweenAttack;
    public float startTimeBetweenAttack;

    public RectTransform attackPos;
    public LayerMask whatIsEnemy;
    public float attackRange;
    public int damage;
    public int loadout;
    private string loadoutType = " ";

    public GameObject projectile;
    private GameObject projectile0;

    // Start is called before the first frame update
    void Start()
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

    // Update is called once per frame
    void Update()
    {

        if (timeBetweenAttack <= 0)
        {
            //attack

            if (Input.GetKey(KeyCode.Space)) //change this to "if in range && has target" or something
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

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
