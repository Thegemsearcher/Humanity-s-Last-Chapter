using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBetweenAttack;
    public float startTimeBetweenAttack;

    private GameObject[] enemiesO;
    public GameObject enemyO;

    public RectTransform attackPos;
    public LayerMask whatIsEnemy;
    public float attackRange;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (timeBetweenAttack <= 0)
        {
            //attack
            if (Input.GetKey(KeyCode.Space)) //change this to "if in range && has target" or something
            {
                
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(transform.position, attackRange, whatIsEnemy);

                for (int i = 0; i < enemiesToDamage.Length; i++) {
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
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
