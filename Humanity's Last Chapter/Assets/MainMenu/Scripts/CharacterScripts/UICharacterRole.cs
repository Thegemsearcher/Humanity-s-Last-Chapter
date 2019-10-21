using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UICharacterRole : MonoBehaviour {

    private string characterName;
    private int characterID, roleID;
    private GameObject[] roles, characters;
    private CharacterScript characterScript;
    public TextMeshProUGUI txtName;

    public void Start() {
        characters = GameObject.FindGameObjectsWithTag("Character");
        roles = GameObject.FindGameObjectsWithTag("role");
    }

    public void GetData(string characterName, int characterID, int roleID) {
        this.characterName = characterName;
        this.characterID = characterID;
        this.roleID = roleID;
        txtName.text = characterName;
    }

    public void Enlist() {
        foreach (GameObject role in roles) {
            if(role.GetComponent<btnAppointScript>().roleId == roleID) {
                role.GetComponent<btnAppointScript>().GetEnlist(characterName, 0, characterID);

                foreach (GameObject character in characters) {
                    characterScript = character.GetComponent<CharacterScript>();
                    if (characterScript.id == characterID) {
                        characterScript.isEnlisted = true;
                        break;
                    }
                }
                break;
            }
        }
        GetComponentInParent<EnlistList>().DestroyChildren();
        //Enlist!
    }
}
