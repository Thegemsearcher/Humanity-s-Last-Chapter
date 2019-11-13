using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponObject : ScriptableObject {
    // Start is called before the first frame update
    public string weaponName = "Weapon name Here";
    public string description = "Info about the weapon";
    public int cost, damage, bullets, wpLevel;
    public float fireRate, range, spread;
    public Sprite sprite;

}
