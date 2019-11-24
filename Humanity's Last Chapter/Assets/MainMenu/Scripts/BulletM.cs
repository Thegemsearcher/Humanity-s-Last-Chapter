using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletM : MonoBehaviour { //Markus
    public float speed;
    public float lifeTime;
    public float distance;
    public LayerMask whatIsSolid;

    private Transform enemy;
    private Vector3 targetPos;
    private Vector3 direction, startPos;
    
    private WeaponObject wo;

    // Start is called before the first frame update
    void Start() {
        targetPos = new Vector3(enemy.position.x + Random.Range(-wo.spread, wo.spread), enemy.position.y + Random.Range(-wo.spread, wo.spread), enemy.position.z);
        startPos = transform.position;
        //transform.rotation = Quaternion.LookRotation(targetPos);
        direction = targetPos - transform.position;
        Invoke("DestroyProjectile", lifeTime);
    }

    public void CreateProjectile(WeaponObject wo, GameObject closestEnemy) {
        this.wo = wo;
        enemy = closestEnemy.transform;
    }

    // Update is called once per frame
    void Update() {
        
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, targetPos, distance, whatIsSolid);
        if (hitInfo.collider != null) {
            if (hitInfo.collider.CompareTag("Enemy")) {
                //Debug.Log("skaträffas");
                hitInfo.collider.GetComponent<Enemy>().TakeDamage(wo.damage);
            }
            DestroyProjectile();
        }

        //velocity = targetPos - transform.position;
        direction.Normalize();
        transform.position += direction * speed * Time.deltaTime;
    }

    void DestroyProjectile() {
        //Instantiate(destroyEffect, transform.position, Quaternion.identity); //to make a visual when bullet collides maybe?
        Destroy(gameObject);
    }
}
