using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage;
    public float speed;
    public float lifeTime;
    public float distance;
    public LayerMask whatIsSolid;

    private Transform enemy;
    private Vector2 target;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindWithTag("Enemy").transform;
        target = new Vector2(enemy.position.x, enemy.position.y);
        //Invoke("DestroyProjectile", lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, target, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);
            }
            DestroyProjectile();
        }

        transform.Translate(target * speed * Time.deltaTime);
    }

    void DestroyProjectile()
    {
        //Instantiate(destroyEffect, transform.position, Quaternion.identity); //to make a visual when bullet collides maybe?
        Destroy(gameObject);
    }
}
