using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Projectile : MonoBehaviour
{
    public int damage;
    public float speed;
    public float lifeTime;
    public float distance;
    public LayerMask whatIsSolid;

    private Transform enemy;
    private Vector3 targetPos;
    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetNearestTarget().transform;
        targetPos = new Vector3(enemy.position.x, enemy.position.y, enemy.position.z);
        //transform.rotation = Quaternion.LookRotation(targetPos);
        velocity = new Vector3(targetPos.x - transform.position.x, targetPos.y - transform.position.y, targetPos.z - transform.position.z);
        Invoke("DestroyProjectile", lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, targetPos, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);
            }
            DestroyProjectile();
        }

        //velocity = targetPos - transform.position;
        velocity.Normalize();
        transform.position += velocity * speed * Time.deltaTime;
    }

    void DestroyProjectile()
    {
        //Instantiate(destroyEffect, transform.position, Quaternion.identity); //to make a visual when bullet collides maybe?
        Destroy(gameObject);
    }


    GameObject GetNearestTarget()
    {
        //so lets say you want the closest target from a array (in this case all Gameobjects with Tag "enemy") and let's assume this script right now is on the player (or the object with which the distance has to be calculated)
        return GameObject.FindGameObjectsWithTag("Enemy").Aggregate((o1, o2) => Vector3.Distance(o1.transform.position, this.transform.position) > Vector3.Distance(o2.transform.position, this.transform.position) ? o2 : o1);
    }
}
