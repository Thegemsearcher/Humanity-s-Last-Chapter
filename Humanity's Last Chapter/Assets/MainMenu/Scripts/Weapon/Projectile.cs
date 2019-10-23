using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Projectile : MonoBehaviour
{
    public int damage;
    public float spread;
    public float speed;
    public float lifeTime;
    public float distance;
    public LayerMask whatIsSolid;

    private Transform enemy;
    private Vector3 targetPos;
    private Vector3 direction;

    public GameObject character;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetNearestTarget().transform;
        targetPos = new Vector3(enemy.position.x + Random.Range(-spread, spread), enemy.position.y + Random.Range(-spread, spread), enemy.position.z);
        //transform.rotation = Quaternion.LookRotation(targetPos);
        direction = targetPos - transform.position;
        Invoke("DestroyProjectile", lifeTime);
    }

    public void CreateProjectile(float spread)
    {
        this.spread = spread;
    }

    // Update is called once per frame
    void Update()
    {
        //if (enemy != null)
        //{
        //    if (enemy.GetComponent<BoxCollider2D>().OverlapPoint(transform.position))
        //    {
        //        //Debug.Log("skaträffas");
        //        enemy.GetComponent<Enemy>().TakeDamage(damage);
        //        DestroyProjectile();
        //    }
        //}
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, direction/*targetPos*/, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo != false/*hitInfo.collider.CompareTag("Enemy")*/)
            {
                //Debug.Log("skaträffas");
                hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);
            }
            DestroyProjectile();
        }

        //velocity = targetPos - transform.position;
        direction.Normalize();
        transform.position += direction * speed * Time.deltaTime;
    }

    void DestroyProjectile()
    {
        //Instantiate(destroyEffect, transform.position, Quaternion.identity); //to make a visual when bullet collides maybe?
        Destroy(gameObject);
    }

    GameObject GetNearestTarget()
    {
        return GameObject.FindGameObjectsWithTag("Enemy").Aggregate((o1, o2) => Vector3.Distance(o1.transform.position, this.transform.position) > Vector3.Distance(o2.transform.position, this.transform.position) ? o2 : o1);
    }
}
