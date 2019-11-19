using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeScript : MonoBehaviour
{
    public Vector3 TargetPos;
    Vector3 direction;
    float dmg = 20, speed = 4;
    // Start is called before the first frame update
    void Start()
    {
        direction = TargetPos - transform.position;
        direction.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, TargetPos) < 0.5f)
        {
            Explode();
        }
        transform.position += direction * speed * Time.deltaTime;
    }
    void Explode()
    {

    }
}
