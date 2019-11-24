using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeScript : MonoBehaviour
{
    public Vector3 TargetPos;
    Vector3 direction;
    int dmg = 40, speed = 4;
    bool explodeOnNext = false;
    GameObject[] enemies;
    // Start is called before the first frame update
    void Start()
    {
        direction = TargetPos - transform.position;
        direction.Normalize();
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        if (explodeOnNext)
        {
            Explode();
            Destroy(gameObject);
        }
        if (Vector2.Distance(transform.position, TargetPos) < 0.5f)
        {
            GetComponent<CircleCollider2D>().radius = 6f;
            explodeOnNext = true;
        }
        transform.position += direction * speed * Time.deltaTime;
    }
    void Explode()
    {
        foreach (GameObject enemy in enemies)
        {
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
            if (GetComponent<CircleCollider2D>().OverlapPoint(enemy.transform.position))
            {
                enemy.GetComponent<SpriteRenderer>().color = Color.green;
                enemy.GetComponent<Enemy>().TakeDamage(dmg);
            }
        }
    }
}
