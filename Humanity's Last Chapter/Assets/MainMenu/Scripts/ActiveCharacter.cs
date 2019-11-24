using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveCharacter : MonoBehaviour {

    private GameObject activeCharacter, pivotCharacter;
    public GameObject WeaponAbility, HealingAbility, CombatAbility;

    private CharacterScript characterScript;
    private Abilities abilities; //Används för att veta vilka abilities karaktären har och veta när de är redo

    public void SwitchCharacter(GameObject activeCharacter, GameObject pivotCharacter) {
        this.activeCharacter = activeCharacter;
        this.pivotCharacter = pivotCharacter;
        characterScript = GetComponent<CharacterScript>();
        abilities = activeCharacter.GetComponent<Abilities>();
        UpdateEquipment();
    }

    private void Update() {
        if (pivotCharacter != null) {
            if (pivotCharacter.GetComponent<Stats>().hp <= 0) {
                ClearEquipment();
            }
        }
        
    }

    private void UpdateEquipment() {
        WeaponAbility.GetComponent<WeaponAbility>().GetItem(activeCharacter);
        HealingAbility.GetComponent<HealingAbility>().GetItem(activeCharacter, pivotCharacter);
        CombatAbility.GetComponent<CombatAbility>().GetItem(activeCharacter, pivotCharacter);
    } 

    private void ClearEquipment() {
        WeaponAbility.GetComponent<WeaponAbility>().GetItem(null);
        HealingAbility.GetComponent<HealingAbility>().GetItem(null, null);
        CombatAbility.GetComponent<CombatAbility>().GetItem(null, null);
    }
}
