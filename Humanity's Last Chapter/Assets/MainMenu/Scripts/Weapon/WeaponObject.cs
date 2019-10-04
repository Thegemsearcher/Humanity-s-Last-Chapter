using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponObject : ScriptableObject {
    // Start is called before the first frame update
    public string WeaponName = "Weapon name Here";
    public string description = "Info about the weapon";
    public int cost, damage;
    public float fireRate, range;
    public Sprite sprite;

}
