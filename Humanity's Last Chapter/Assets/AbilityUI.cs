using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityUI : MonoBehaviour {
    public GameObject CombatAbility, WeaponAbility, HealingAbility;
    private GameObject Character, Holder;
    private string combatID, weaponID, healingID;

    public void GetNewCharacter(GameObject Character, string combatID, string weaponID, string healingID) {
        this.Character = Character;
        this.combatID = combatID;
        this.weaponID = weaponID;
        this.healingID = healingID;

        if(combatID != "" || combatID != null) {
            foreach (CombatItemObject combatItem in Assets.assets.combatTemp) {
                if(combatItem.name == combatID) {
                    CombatAbility.GetComponent<CombatAbility>().GetData(combatItem);
                    break;
                }
            }
        } else {
            CombatAbility.GetComponent<CombatAbility>().GetData(null);
        }

        if (weaponID != "" || weaponID != null) {
            foreach (WeaponObject weapon in Assets.assets.weaponTemp) {
                if (weapon.name == weaponID) {
                    WeaponAbility.GetComponent<WeaponAbility>().weapon = weapon;
                    break;
                }
            }
        } else {
            WeaponAbility.GetComponent<WeaponAbility>().weapon = null;
        }

        
        if (healingID != "" || healingID != null) {
            foreach (HealingItemObject healingItem in Assets.assets.healingTemp) {
                if (healingItem.name == healingID) {
                    HealingAbility.GetComponent<HealingAbility>().GetData(healingItem, Character);
                    break;
                }
            }
        } else {
            HealingAbility.GetComponent<HealingAbility>().GetData(null, null);
        }

    }
}
