using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public GameObject weapon;
    private GameObject weapon0;

    // Start is called before the first frame update
    void Start()
    {
        weapon0 = Instantiate(weapon, gameObject.transform.parent.position, Quaternion.identity);
        weapon0.transform.parent = gameObject.transform;
        weapon0.transform.localScale = new Vector3(1, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
