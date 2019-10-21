using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnlistList : MonoBehaviour {

    private GameObject[] characters;
    private GameObject Holder;
    public GameObject UIRole;
    private CharacterScript characterScript;
    
    public void IsEnlisted(int roleID) {
        characters = GameObject.FindGameObjectsWithTag("Character");
        foreach (GameObject character in characters) {
            characterScript = character.GetComponent<CharacterScript>();

            //If missionReady and !inHospital
            if(!characterScript.isEnlisted && !characterScript.inHospital) {
                Holder = Instantiate(UIRole);
                Holder.GetComponent<UICharacterRole>().GetData(characterScript.name, characterScript.id, roleID);
                Holder.transform.SetParent(transform, false);
            }
        }
    }

    public void DestroyChildren() {
        foreach (Transform child in transform) {
            Destroy(child.gameObject);
        }
    }
}
