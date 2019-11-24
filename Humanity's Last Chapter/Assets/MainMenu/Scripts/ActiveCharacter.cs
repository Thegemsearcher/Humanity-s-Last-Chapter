using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveCharacter : MonoBehaviour {

    private GameObject activeCharacter;
    public GameObject WeaponAbility, HealingAbility, CombatAbility;

    private CharacterScript characterScript;
    private Abilities abilities; //Används för att veta vilka abilities karaktären har och veta när de är redo

    public void SwitchCharacter(GameObject activeCharacter) {
        this.activeCharacter = activeCharacter;
        characterScript = GetComponent<CharacterScript>();
        abilities = activeCharacter.GetComponent<Abilities>();
        UpdateEquipment();
    }

    private void UpdateEquipment() {
        WeaponAbility.GetComponent<WeaponAbility>().GetItem(activeCharacter);
        HealingAbility.GetComponent<HealingAbility>().GetItem(activeCharacter);
        CombatAbility.GetComponent<CombatAbility>().GetItem(activeCharacter);
    } 
}
