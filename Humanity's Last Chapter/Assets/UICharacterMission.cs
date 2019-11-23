using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICharacterMission : MonoBehaviour {

    private GameObject AbilityUI; //Rutan längst ner till höger i MissionMap
    private CharacterScript characterScript;

    private void Start() {
        AbilityUI = GameObject.FindGameObjectWithTag("AbilityUI");
        characterScript = GetComponent<CharacterScript>();
    }

    public void BtnSelectCharacter() {
        AbilityUI.GetComponent<AbilityUI>().GetNewCharacter(gameObject, characterScript.activeCombat, characterScript.rangedId, characterScript.activeHealing);
    }
}
