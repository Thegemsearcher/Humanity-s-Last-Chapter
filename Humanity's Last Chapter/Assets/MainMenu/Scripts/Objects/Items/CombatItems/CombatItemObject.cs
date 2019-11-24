using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AbilityScript;
using static CombatAbility;

[System.Serializable]
public class CombatItemObject : ScriptableObject {

    public Sprite icon;
    public Sprite sprite;
    public string itemName = "t.ex. Strong Cookie";
    public string description = "t.ex. This cookie will give you strong power!!!";
    public int cost;
    public int coolDownTimer;
    public int placeRange;
    public int damage; //Grenade Damage
    public float aoe; //Area of Effect (Grenade blast)
    public AbilityType abilityType;
    public CombatType combatType;
    public WeaponObject attachedWeapon;
    
    public GameObject AttachedAbility;
}
