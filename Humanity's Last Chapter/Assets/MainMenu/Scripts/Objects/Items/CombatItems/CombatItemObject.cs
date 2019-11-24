using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static AbilityScript;
using static CombatAbility;

[System.Serializable]
public class CombatItemObject : ScriptableObject {

    public Sprite texture;
    public CombatType abilityType;
    public string itemName = "t.ex. Strong Cookie";
    public string description = "t.ex. This cookie will give you strong power!!!";
    public int cost;
    public int damage;
    public float range;
    public float aoe;
    public float cooldownTimer;

    //TurretStats:
    public float fireRate;
    public float weaponSpread;
    public int turretTimer;
}
