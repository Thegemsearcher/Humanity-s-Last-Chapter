using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public GameObject weapon;
    private GameObject weaponO;

    // Start is called before the first frame update
    void Start()
    {
        //weaponO = Instantiate(weapon, gameObject.transform.position, Quaternion.identity);
        //weaponO.transform.parent = gameObject.transform;
        //weaponO.transform.localScale = new Vector3(1, 1, 1);
    }
}
